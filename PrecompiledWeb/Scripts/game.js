var holder = '#holder';
var rows = 36;
var cols = 18;
var interval;
var speed = 100;
var isGameRunning = false;
var lastCelsAlive = []; //an array that store the last cells alive and compares it with the next set to see of and end has reached

var presets = {
    eight: ['#r7c17', '#r7c18', '#r7c19', '#r8c17', '#r8c18', '#r8c19', '#r9c17', '#r9c18', '#r9c19', '#r10c20', '#r10c21', '#r10c22', '#r11c20', '#r11c21', '#r11c22', '#r12c20', '#r12c21', '#r12c22'],
    blinkers: ['#r9c18', '#r9c19', '#r9c20'],
    fpimento: ['#r9c19,#r9c20,#r10c18,#r10c19,#r11c19'],
    beacon: ['#r8c18,#r8c19,#r9c18,#r9c19,#r10c20,#r10c21,#r11c20,#r11c21']
};

$(document).ready(function () {
    createGrid(cols, rows);
    initGameOfLife();

    $('.preset').click(function () {
        applyPreset($(this).html().toLowerCase());
    });

});

function initGameOfLife() {
    $(holder + ' td').click(function () {
        if (parseInt($(this).attr('status'))) {
            $(this).removeClass('cel');
            $(this).attr('status', 0);
        }
        else {
            $(this).addClass('cel');
            $(this).attr('status', 1);
        }
    });
    $('#start').click(startGameOfLife);
    $('#stop').click(stopGameOfLife);
    $('#reset').click(resetGameOfLife);
}

function startGameOfLife() {
    //check if some cels are selected
    if ($('.cel').length && !isGameRunning) {
        trace('starting game of life!');
        isGameRunning = true;
        interval = setInterval(game, speed);

    }

    if ($('.cel').length == 0) alert('Select some cels by clicking on them and then click Start!');
}

function game() {
    trace('...');
    //collect cells which will live and the ones which will die
    cLiveArr = [];
    cDieArr = [];

    //run a loop on all the cels and see check their status
    $(holder + ' td').each(function () {

        if (parseInt($(this).attr('status'))) {
            //this cell is 'on'
            //it must have 2 OR 3 neighbouring cells 'on' in order to stay on
            //get neighbours
            var nArr = getNeighboringCels('#' + $(this).attr('id'));
            var nArrAliveNum = 0;
            for (var i = 0; i < nArr.length; i++) {
                if (parseInt($(nArr[i]).attr('status'))) {
                    nArrAliveNum++;
                }
            }
            if (nArrAliveNum == 2 || nArrAliveNum == 3) {
                //this cel can continue to live
            }
            else {
                //this cel must die
                cDieArr.push($(this));
            }
        }
        else {
            //this cell is 'off'
            //it must have 3 neighbouring cells 'on' in order to turn on
            var nArr = getNeighboringCels('#' + $(this).attr('id'));
            var nArrAliveNum = 0;
            for (var i = 0; i < nArr.length; i++) {
                if (parseInt($(nArr[i]).attr('status'))) {
                    nArrAliveNum++;
                }
            }
            if (nArrAliveNum == 3) {
                //this cel come alive
                cLiveArr.push($(this));
            }
            else {
                //this cel cannot come alive
            }
        }
    });

    //bring to life or kill cells from collection
    for (var i = 0; i < cLiveArr.length; i++) {

        selectCel(cLiveArr[i]);
    }

    for (var i = 0; i < cDieArr.length; i++) {
        unselectCel(cDieArr[i]);
    }

    //check if all cels are dead.. if so then stop the game
    if ($('.cel').length < 1) {
        alert('All cells dead! GAME OVER!');
        resetGameOfLife();
    }

}

function stopGameOfLife() {
    trace('stopping game of life');
    isGameRunning = false;
    clearInterval(interval);
}

function resetGameOfLife() {
    stopGameOfLife();
    trace('reseting game of life');
    $('.cel').each(function () {
        unselectCel($(this));
    });

    if (typeof window.console != 'undefined' && typeof window.console.log != 'undefined') console.clear();
}

//gol helpers

var rowsArr = [];
var totalRows;
var totalCols;

function createGrid(rows, cols) {
    //create a table with specified number of columns and rows inside the holder
    totalRows = rows;
    totalCols = cols;

    var htmlStr = '';
    htmlStr += '<table>';
    for (var i = 0; i < rows; i++) {
        htmlStr += '<tr>';
        var arr = [];
        for (var j = 0; j < cols; j++) {
            htmlStr += '<td id="r' + i + 'c' + j + '" r="' + i + '" c="' + j + '" status="0">';
            //htmlStr += '#' + 'r'+i+'c'+j;
            htmlStr += '</td>';
            arr.push('#' + 'r' + i + 'c' + j);
        }
        rowsArr.push(arr);

        htmlStr += '</tr>';
    }
    htmlStr += '</table>';

    $(holder).append(htmlStr);

    var nArr = getNeighboringCels('#r7c17');
    console.log(nArr);
}

function getNeighboringCels(cel) {
    //get the neighboring cells for the given cel ('#r3c5')
    var arr = [];

    //VERTICAL HORIZONTAL
    //get top and bottom cels
    var tbArr = getTopBottomCels(cel);
    arr = arr.concat(tbArr);

    //get left and right cels
    var lrArr = getLeftRightCels(cel);
    arr = arr.concat(lrArr);

    //DIAGONAL
    //get the left and right of the top and bottom cels
    for (var i = 0; i < tbArr.length; i++) {
        arr = arr.concat(getLeftRightCels(tbArr[i]));
    }

    //get the top and bottom of left and right cels
    for (var i = 0; i < lrArr.length; i++) {
        arr = arr.concat(getTopBottomCels(lrArr[i]));
    }

    return arr.unique();
}

//the following 2 functions need to be separate coz they will be also run on their results individually for getting diagonal elements
function getTopBottomCels(cel) {
    //return an array of (2) cels that are on the top and bottom of the given cel
    var arr = []; 	//array to return
    //get the id for the rowsArr
    var rowId = parseInt($(cel).attr('r'));
    //get the col id for the rowsArr[rowId] array
    var colId = parseInt($(cel).attr('c'));
    //get the cel that s above the given cel if rowId is > 0
    if (rowId > 0) arr.push(rowsArr[rowId - 1][colId]);
    //get the cel that s below the given cel if rowId is < totalRows-1
    if (rowId < (totalRows - 1)) arr.push(rowsArr[rowId + 1][colId]);
    return arr;
}

function getLeftRightCels(cel) {
    //return an array of (2) cels that are on the left and right of the given cel
    var arr = []; 	//array to return
    //get the id for the rowsArr
    var rowId = parseInt($(cel).attr('r'));
    //get the col id for the rowsArr[rowId] array
    var colId = parseInt($(cel).attr('c'));
    //get the cel that s before the given cel if colId is > 0
    if (colId > 0) arr.push(rowsArr[rowId][colId - 1]);
    //get the cel that s after the given cel if colId is < totalCols-1
    if (colId < (totalCols - 1)) arr.push(rowsArr[rowId][colId + 1]);
    return arr;
}

function selectCel(cel) {
    cel.attr('status', 1);
    cel.addClass('cel');
}

function unselectCel(cel) {
    cel.attr('status', 0);
    cel.removeClass('cel');
}

function applyPreset(p) {
    resetGameOfLife();
    for (var i = 0; i < presets[p].length; i++) {
        selectCel($(presets[p][i]));
    }

}

//general helpers//
function trace(val) {
    if (typeof window.console != 'undefined' && typeof window.console.log != 'undefined') {
        if (typeof val == 'string') console.log(val);
        else console.log(val.toString());
    }
}

Array.prototype.unique = function () {
    var r = [];
    for (var i = 0; i < this.length; i++) {
        if (r.indexOf(this[i]) == -1)
            r.push(this[i]);
    }
    return r;
}
