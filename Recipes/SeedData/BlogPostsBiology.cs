﻿
namespace Recipes.SeedData
{
    public class BlogPostsBiology
    {
        //"Models in Biology"
        public const string content_27112011_b = "<p>Here is my mini-assignment on the models in biology in general.</p><p><strong>Models in Biology: Population growth model</strong></p><p><u>1. An example of a model in biology</u></p><p>Mathematical models can be applied to the study of population dynamics. Population dynamics have been studied for the last couple of years and a number of models have been developed over that time. One of the first approaches was developed by Thomas Malthus, who became widely known for his theories about population and his model is now known as the simple logistic model, also called the Malthus model.</p>";
        public const string content_27112011_r = "<p><u>2. What is the purpose of the model</u></p><p>In general, the population growth model helps understand processes that occur in the ecological system. In particular, if applied to human population, for example, the model may be used to predict the population growth and approach the potential problems that the growth will cause, such as overpopulation, shortage of housing or fresh water, pollution and similar.</p>" +
            "<p><u>3. What does the model represent</u></p><p>In fact, there are multiple models of the population growth and the complete list is probably outside the scope of this exercise. Generally, the population growth model is a total number of species in the population as a function of time t, and there are multiple factors that influence the result of the function. More complex models consider more factors and are more accurate.</p><p><u>4. How is it represented</u></p>" +
            "<p>The simplest model may be the arithmetic model. In this case the population is defined as follows:</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/27112011_Equation_1.png\" alt=\"Equation 1\" /></div>" +
            "<p>And the population size is a simple function of births, immigration, deaths and emigration. While this model may be accurate in retrospect, it is not very useful in predicting the population growth because the variables on the right side of the equation are generally not known beforehand.</p><p>Another well-known model is an exponential model</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/27112011_Equation_2.png\" alt=\"Equation 1\" /></div>" +
            "<p>This model assumes that the population grows at a certain rate r. This model is a simplification because it makes several assumptions, such as the rate being constant, ignoring emigration and immigration and ignoring restrictions on population growth which will inevitably apply.</p><p>A logistic growth model appears to be more advanced.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/27112011_Equation_3.png\" alt=\"Equation 1\" /></div>" +
            "<p>Compared to the exponential model, this model takes into account the carrying capacity K, which is the maximum sustainable population size or, simply, the largest amount of species the environment can support. As the population size approaches K, the population grows and the population size N can never be larger than K. This model still makes certain assumptions, such as that K remains constant, and influence of immigration and emigration is ignored too.</p><p><u>5. Is the representation accurate?</u></p><p>None of the models mentioned above appears to be exactly accurate. For example, the exponential growth model is fairly accurate at the initial phase. However, at a later stage a lot of other effects become significant which are not considered by the model.</p>" +
            "<p><u>6. How could you validate your model?</u></p><p>The model can be simulated by computational methods but that, of course, does not say anything about the validity of the model. Intuitively, it appears that the model can not be proven valid; the best possible outcome would be to estimate the range of the possible error. Even in a relatively simple case, for example a model of a bacterial growth under known conditions, it is unlikely that the population size will be exactly equal to the predicted value. If we repeat the experiment a number of times, the resulting population size will probably be in a certain range, following a normal distribution. In complex models, such as the human population size, the estimates may be in much wider range. For example, the projections of human population in 2050 made by UN range from low 8 billion to high 10.5 billion. The best case for validating the model is to be able to explain the actual observed data within the experimental error.</p><p><u>7. Additional information</u></p>" +
            "<p>The population growth models are just the basics of the population biology. The models above only apply to the population of a single species. However, most species on the planet interact with other species and mutually influence their population sizes. One of the examples of a model involving two species is the parasite-host system. Such model will consider additional factors compared to single-species model: hosts that carry parasites will give rise to the next generation of parasites, while host that do not carry parasites will produce their own offspring, the fraction of the hosts that are parasitized depend on the rate of the encounters of the two species etc. Another possible example is the interaction between a plant species and a herbivore. Such models generally require differential equations to describe them.</p>";
        public const string content_27112011_k = "bioinformatics biology modeling";
        public const string content_27112011_d = "Essay on models in biology in general";

        public const string content_07122011_b = "<p>Cytoscape is a popular open source platform for visualising molecular interaction networks.</p><a href=\"http://www.cytoscape.org\">Cytoscape website</a><p>Cytoscape has a built-in plugin manager (Plugins -> Manage Plugins) which lets the user install a large number of plugins.</p>";
        public const string content_07122011_r =
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/07122011_Cytoscape_Desktop.png\" alt=\"Cytoscape Desktop\" /></div>" +
            "<p>One of the most important applications of Cytoscape is the analysis of interaction networks. The networks are described by eXtensible Graph Markup and Modeling Language - XGMML.</p>" +
            "<a href=\"http://en.wikipedia.org/wiki/XGMML\">XGMML</a><p>I found a sample file here</p><a href=\"http://www.rbvi.ucsf.edu/Research/cytoscape/structureViz/pte.xgmml\">pte.xgmml</a>" +
            "<p>To import the file into Cytoscape, select File -> Import -> Network(multiple file types)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/07122011_Cytoscape_Network_Multiple_File_Types.png\" alt=\"Cytoscape Network Multiple File Types\" /></div>" +
            "<p>This is how a network typically may look.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/07122011_Cytoscape_Network_Edges.png\" alt=\"Cytoscape Network Edges\" /></div>" +
            "<p>To view all nodes and edges, apply a layout, for example Layouts -> Cytoscape Layouts -> Spring Embedded</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/07122011_Cytoscape_Network_Edges_Small.png\" alt=\"Cytoscape Network Edges\" /></div>" +
            "<p>In the Node Attribute Browser below, click \"Select All Attributes\". To select all nodes in the Cytoscape model, use Ctrl-A.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/07122011_Cytoscape_Data_Panel.png\" alt=\"Cytoscape Data Panel\" /></div>" +
            "<p>If the network is large, it is possible to use a selection criteria to select nodes of interes and to create a new network from the selected nodes only. For example, it is possible to sort the nodes by an attribute in the node attribute browser (or edge attribute browser), select a number of nodes and then select File -> New -> Network -> From Selected Nodes, All Edges. Cytoscape will create a child subnetwork which will only include selected nodes and/or edges.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/07122011_Cytoscape_All_Edges_From_Selected_Nodes.png\" alt=\"Cytoscape All Edges From Selected Nodes\" /></div>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/07122011_Cytoscape_Child_Subnetwork.png\" alt=\"Cytoscape Child Subnetwork\" /></div>";
        public const string content_07122011_k = "bioinformatics biology modeling cytoscape";
        public const string content_07122011_d = "Cytoscape - a popular open source platform for visualising molecular interaction networks.";

        //"Markov Chains Monte Carlo Bayesian Inference"
        public const string content_13092012_b = "<p><strong>1. Bayesian Inference</strong></p><p>Bayesian rule is a mathematical rule that explains how the estimate of the probability changes as new evidence is collected. It relates the odds of event <strong>A<sub>1</sub></strong> to event <strong>A<sub>2</sub></strong> before and after conditioning on event <strong>B</strong> (1).</p>";
        public const string content_13092012_r =
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Equation_1.png\" alt=\"Equation 1\" /></div>" +
            "<p>As an example, assume that there is a bag containing black and white balls, but the percentage of colours is unknown. As more and more balls are drawn from the bag, the probability of the next ball being white (or black) can be calculated with higher precision. In this case, <strong>A<sub>1</sub></strong> is the probability of white ball being drawn, <strong>A<sub>2</sub></strong> of the black ball, and <strong>B</strong> is the set of the balls already drawn, such as “of 10 balls 4 were black and 6 were white”.</p><p>Frequentist approach to Bayes’ rule is to consider probabilities of <strong>A<sub>1</sub></strong> and <strong>A<sub>2</sub></strong>" +
            " as known and fixed, while in Bayesian they are considered random variables. Bayesian approach also considers prior probability, or just the prior, which expresses uncertainty before the data is taken into account. It makes possible to introduce subjective knowledge of the problem into the model in the form of prior information. Among the drawbacks of the approach is the need to evaluate multi-dimensional integrals numerically, which gets worse as the number of parameters in the system increases. Introduction of conjugate prior is an attempt to solve these drawbacks. Conjugate prior is such prior distribution that the prior and posterior are in the same family of distributions. Markov Chains are useful because under certain conditions, a memoryless process can be generated which has the same limiting distribution as the random variable that the calculation is trying to simulate.</p><p><strong>2. Markov Chains</strong></p><p>A Markov chain is a process which can be in a number of states." +
            " The process starts in one of the states and moves successively from one to another. Each move is called a step. At each step a process has a probability to move to another state, and the probability does not depend on any of the previous states of the process. That is why such process is called “memoryless”.</p><p>Example: In a weather model, a day can be either nice, rainy or snowy. If the day is nice, the next day will be either rainy or snowy with 50% probability. If the day is rainy or snowy, it will stay the same with 50% probability, or will change to one of the other two possibilities with 25% probability. This is a Markov chain because the process determines its next state base on the current state only, without any prior information. The probabilities can be presented in the transition matrix (2).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Probability_Matrix.png\" alt=\"Probability Matrix\" /></div>" +
            "<p>The first row presents the probabilities of the next day’s weather if today is rainy (R): ½ that it will remain rainy, ¼ that it will be nice and ¼ that it will be snowy. The sum of probabilities across the row must be equal to 1.</p><p><strong>3. Monte Carlo Methods</strong></p><p>Markov Chains Monte Carlo (MCMC) methods are computational algorithms which randomly sample from the process. The aim of the methods is to estimate something that is too difficult or time consuming to find deterministically. Using the example above, assume that the probabilities in the matrix are not known. A MCMC could simulate a thousand rainy days and count the number of snowy, rainy and nice days that follow. The same could be repeated for snowy and nice days.</p>" +
            "<p>The original Monte Carlo approach was developed to use random number generation to compute integrals. If a complex integral can be decomposed into a function <i>f(x)</i> and a probability density function <i>p(x)</i>, then the integral can be expressed as an expectation of <i>f(x)</i> over the density <i>p(x)</i> (3)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Equation_2.png\" alt=\"Equation 2\" /></div>" +
            "<p>Now, if we draw a large number of x<sub>1</sub>, ..., x<sub>n</sub> of random variables from the density <i>p(x)</i>, then we end up with (4), which is referred to as Monte Carlo integration.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Equation_3.png\" alt=\"Equation 3\" /></div>" +
            "<p><strong>3.1. Markov Chain Convergence</strong></p><p>It can be shown that if matrix <i>P</i> is the transition matrix for a Markov chain and <i>p<sub>ij</sub></i> element is the probability of transitioning from state <i>i</i> to state <i>j</i>, then the element <i>p<sub>ij</sub><sup>(n)</sup></i> of the matrix <i>P<sup>n</sup></i> gives the probability that the Markov chain starting in state <i>s<sub>i</sub></i> will be in state <i>s<sub>j</sub></i> after <i>n</i> steps. Using the transitional matrix (2), on the sixth step of multiplying the matrix by itself the following state will be reached (5). Such Markov chain is called regular (not all Markov chains are regular). The long-range predictions for this chain are independent of the starting state.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Probability_Matrix_2.png\" alt=\"Probability Matrix 2\" /></div>" +
            "<p>Continuing the example, assume that the initial probabilities for the weather conditions on the starting day of the chain are equal. This will be called a probability vector, which in the example will be as shown in (6).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Vector_1.png\" alt=\"Vector 1\" /></div>" +
            "<p>It can be shown that the probability of the chain being in the state <i>s<sub>i</sub></i> after <i>n</i> steps is the <i>i</i>th entry in the vector (7).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Vector_2.png\" alt=\"Vector 2\" /></div>" +
            "<p>If, as in the example, the chain is regular, it will converge to a stationary distribution, when the probability of the chain being in state <i>i</i> is independent of the initial distribution. In the weather example, the stationary distribution is shown in (8).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Vector_3.png\" alt=\"Vector 3\" /></div>" +
            "<p><strong>3.2. Ergodicity and Reversibility</strong></p><p>If the process that starts from state <i>i</i> will ever re-enter state <i>i</i>, such state is called recurrent. Additionally, such state is called nonnull if it re-enters state <i>i</i> in <i>n</i> steps, where <i>n</i> is finite. A process is called aperiodic if the greatest common divisor of return steps to any state is 1. For example, if the chain re-enters a state after 2, 4, 6 steps and so on, such chain is not aperiodic. A process is called irreducible if any state can be reached from any other state in a finite number of moves. A chain that is recurrent nonnull, aperiodic and irreducible is called ergodic, and the ergodic theorem states that a unique limiting distribution exists for the chain and such distribution is independent of initial distribution.</p>" +
            "<p>A Markov chain is reversible if (9) is satisfied for all <i>i, j</i>, where <i>u</i> is the stationary distribution and <i>p<sub>ij</sub></i> are elements of the transition matrix.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Equation_4.png\" alt=\"Equation 4\" /></div>" +
            "<p>Ergodicity and reversibility are the two principles behind the Metropolis-Hastings algorithms.</p><p><strong>3.3. Metropolis-Hastings algorithms</strong></p><p>One of the problems of applying Monte Carlo integration is in obtaining samples from some complex probability distribution." +
            " Mathematical physicists attempted to integrate complex functions by random sampling. Metropolis showed how to construct the desired transition matrix and later Hastings generalized the algorithm. The essential idea of the algorithm is to construct a reversible Markov chain for given distribution <i>&pi;</i> such, that its stationary distribution is <i>&pi;</i>. It starts with generating the candidate <i>j</i> from a proposal transition matrix <i>Q</i>. This matrix <i>Q</i> transitions from current state <i>i</i> to proposal <i>j</i>. Proposal <i>j</i> is then accepted with some probability <i>&alpha;<sub>ij</sub></i>. If the rejection takes place, then the next state retains the current value. The summary of the algorithm is as follows:</p><ul><li>Start with arbitrary <i>X<sub>0</sub></i>." +
            " Then, at each iteration <i>t = 1, ..., N</i>:</li><li>Sample <i>j</i>~<i>q<sub>ij</sub></i>. Q={<i>q<sub>ij</sub></i>} is the transition matrix.</li><li>Generate <i>u</i> – a uniformly distributed random number between 0 and 1.</li><li>With probability (9.1), if <i>u <= &alpha;<sub>ij</sub></i>, set <i>X<sub>t+1</sub> = j</i>, else set <i>X<sub>t+1</sub> = i</i>.</li></ul>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Equation_5.png\" alt=\"Equation 5\" /></div>" +
            "<p>Such algorithm randomly attempts to move about the sample space, sometimes accepting the transitions and sometimes remaining in the same state." +
            " Acceptance ratio indicates how probable the proposed sample is in respect to the current sample. If the next state is more probable than the current, the transition is always accepted. If the next step is less probable, it will be occasionally accepted, but more often rejected. Intuitively, this is why this algorithm works, tending to stay away from the regions with low-density and mostly remaining in the high-density regions.</p><p>A key issue in the successful implementation of the algorithm is the number of steps until the chain approaches stationarity, which is called the burn-in period. Typically first 1000 to 5000 elements are thrown out and then a test is used to assess whether stationarity has been reached.</p><p><strong>3.4. Gibbs Sampling</strong></p><p>Gibbs sampling is a special case of Metropolis-Hastings sampling where the random value is always accepted. The key is the fact that only distributions where all random variables but one are assigned fixed values are considered. The benefit is that such distributions are much easier to simulate compared to complex joint distributions." +
            " Instead of generating a single <i>n</i>-dimensional vector in a single pass, <i>n</i> random variables are simulated sequentially from the <i>n</i> conditionals.</p><p>A Gibbs stopper is an approach to convergence based on comparing the Gibbs sampler and the target distribution. Weights are plotted as a function of the sampler iteration number. As the sampler approaches stationarity, the distribution of weights is expected to spike.</p><p><strong>4. Example</strong></p><p><strong>4.1. Initial Data</strong></p><p>Table 1 contains the field goal shooting record of LeBron James for the seasons 2003 to 2009. The goal of the simulation was to use OpenBUGS to carry out a MCMC Bayesian simulation and produce a posterior distribution to the probability of the player’s shooting success.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_LeBron_James_Goal_Shooting_Record.png\" alt=\"LeBron James Goal Shooting Record\" /></div>" +
            "<p align=\"center\">Table 1 – LeBron James Goal Shooting Record</p><p><strong>4.2. The Model</strong></p><p>The model for the success probabilities of LeBron James is given by (10)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Equation_6.png\" alt=\"Equation 6\" /></div>" +
            "<p>where <i>k = 2, ..., 7</i>, corresponding to seasons from 2004/5 to 2009/10, and <i>&pi;<sub>1</sub></i> is estimated individually as a success probability for 2003/4 season. <i>R<sub>k</sub></i> are performances for the current seasons. A beta prior is the success probability for the first season and gamma priors are relative successes <i>R<sub>k</sub></i>.</p><p>Likelihood for this model is given by (11).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Equation_7.png\" alt=\"Equation 7\" /></div>" +
            "<p>The likelihood is written in OpenBUGS as</p><pre class=\"brush: cpp\">for (k in 1:YEARS){ y[k]  ~ dbin( pi[k], N[k] ) }</pre><p>while the model for success probabilities is expressed as follows:</p><pre class=\"brush: cpp\">" +
            @"for (k in 2:YEARS){ pi[k]<-pi[k-1]*R[k] }" +
            "</pre><p>The data for the model specifies the values of the successes and total attempts (<i>y<sub>i</sub></i> and <i>N<sub>i</sub></i>) for each season. Initial values for the model must be specified for <i>&pi;<sub>1</sub></i> and <i>R<sub>k</sub></i> as follows:</p><pre class=\"brush: cpp\">" +
            @"list(pi=c(0.5, NA, NA, NA, NA, NA, NA), R=c(NA, 1,1,1,1,1,1))" +
            "</pre><p>No initial values were specified for <i>&pi;<sub>2</sub></i> ... <i>&pi;<sub>7</sub></i> since they are deterministic and for <i>R<sub>1</sub></i> since it is constant. Actual initial data used for the model is attached as separate initX.txt files, where X is the number of the chain.</p><p><strong>4.3. One Chain Calculation</strong></p><p>The initial calculation was run with 1000 samples burn-in and 2000 sample points, for one chain. The posterior summaries were presented in Figure 1</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Posterior_summaries_for_one_chain_calculation.png\" alt=\"Posterior summaries for one chain calculation\" /></div>" +
            "<p align=\"center\">Figure 1 – Posterior summaries for one chain calculation</p><p>From these results, the expected success rates for James LeBron was 42.24% for the season of 2003/4, increased by a factor of 1.1 for the season of 2004/5, then stayed close to the level of 2003/4 season for the next 2 seasons (posterior means for <i>R<sub>3</sub></i> = 1.036 and <i>R<sub>4</sub></i> = 0.9863) and then was increasing steadily for the next 3 seasons.</p><p>Since <i>R<sub>i</sub></i> indicates the relative performance of a current season in comparison to the previous one, it can be reported that the player was steadily increasing his performance over the duration of the seven season, with one especially significant increase of 10.5% early in the career.</p><p>Further, posterior distributions of the relative performance vector <i>R</i> were analysed by using the Inference -> Compare function and producing the boxplot, which is presented in Figure 2.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_The_boxplot_of_R.png\" alt=\"The boxplot of R\" /></div>" +
            "<p align=\"center\">Figure 2 – The boxplot of R</p><p>The limits of boxes represent the posterior quartiles and the middle bar – the posterior mean. The endings of the whisker lines are 2.5% and 97.5% posterior percentiles.</p><p>Posterior density can be estimated by plotting the success rate density for a season. Figure 3 represents the posterior density for each season (<i>&pi;<sub>i</sub></i>)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Posterior_density_for_each_season.png\" alt=\"Posterior density for each season\" /></div>" +
            "<p align=\"center\">Figure 3 – Posterior density for each season</p><p>Checking convergence is not a straightforward task. While it is usually easy to say when the convergence definitely was not reached, it is difficult to conclusively say if the chain has converged." +
            " Convergence can be checked by using the trace option from <strong>Inference -> Samples</strong> menu. Figure 4 represents the history plots for <i>&pi;<sub>i</sub></i>.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_History_Plots_for_one_chain.png\" alt=\"History Plots for one chain\" /></div>" +
            "<p align=\"center\">Figure 4 – History Plots for <i>&pi;<sub>i</sub></i>, one chain</p><p>It is clear that <i>&pi;<sub>7</sub></i> has converged, while the result for other seasons is not so obvious. Multiple chain calculation with a higher number of iterations may be helpful. Another reason to use the higher number of iterations is the reduction of Monte Carlo error in case it is too high – it decreases as the number of iteration grows. In fact, the value of Monte Carlo error can be used to decide when to stop simulation.</p>" +
            "<p><strong>4.4. Multiple chain calculation</strong></p><p>The main difference between the single and multiple chain calculations is the fact that a separate set of initial values is required for each chain. The following initial values were used for the three chains:</p><pre class=\"brush: cpp\">" +
            @"list(pi=c(0.5, NA, NA, NA, NA, NA, NA), R=c(NA, 1,1,1,1,1,1))
            list(pi=c(0.9, NA, NA, NA, NA, NA, NA), R=c(NA, 1,1,1,1,1,1))
            list(pi=c(0.1, NA, NA, NA, NA, NA, NA), R=c(NA, 1,1,1,1,1,1))" +
            "</pre><p>The posterior statistics for this calculation were presented in Figure 5.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_Posterior_summaries_for_multiple_chain_calculation.png\" alt=\"Posterior summaries for multiple chain calculation\" /></div>" +
            "<p align=\"center\">Figure 5 – Posterior summaries for multiple chain calculation</p><p>The trace plots now contain one line for each chain. The history plots for <i>&pi;<sub>i</sub></i> for this calculation were presented in Figure 6.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/13092012_History_Plots_for_multiple_chains.png\" alt=\"History Plots for multiple chains\" /></div>" +
            "<p align=\"center\">Figure 6 – History Plots for <i>&pi;<sub>i</sub></i>, multiple chains</p><p><strong>References</strong></p><p>Ntzoufras I, <i>Bayesian Modeling Using WinBUGS</i>, 2009, Wiley, England</p><p>Reich B, Hodges J, Carlin B, Reich A, <i>A Spatial Analysis of Basketball Shot Chart Data</i>, 2005, NSCU Statistics</p><p>Walsh B, <i>Markov Chain Monte Carlo and Gibbs Sampling</i>, 2004, MIT Lecture Notes</p><p><i>Mathematics for Metabolic Modelling</i> - Course Materials 2012, University of Manchester, UK</p>";
        public const string content_13092012_k = "bioinformatics digital biology markov chain monte carlo methods bayesian inference";
        public const string content_13092012_d = "Markov Chains Monte Carlo Bayesian Inference";

        //"Statistical Inference"
        public const string content_04082012_b = "<p><strong>1. Introduction</strong></p><p>Inferential statistics give the basis to draw conclusions (or inferences) from the data and to evaluate the confidence in these conclusions being true. The need for inference is dictated by the fact that it is usually impossible to measure the parameter of interest in the whole population. The best alternative is to select a sample from the population and make the measurements. Then a conclusion may be derived about the population as a whole. However, due to a random chance, a sample may not represent the population well enough (i.e. most people in the sample may have higher than average resistance to the disease of interest). Therefore, the probability of such a coincidence has to be estimated as well.</p>";
        public const string content_04082012_r =
            "<p>The inferential statistics are generally considered a separate topic from descriptive statistics, which is mostly about the presentation of factual data.</p><p><strong>2. Categories of Statistical Inference</strong></p><p><strong>2.1 Estimation</strong></p><p>The population parameters can be estimated based on measuring the parameters of a sample and then calculating the mean and variance. These values can not tell what exactly the population parameters are. When a different sample is chosen, the values will differ slightly. Therefore, it is only possible to say that there is a certain confidence that the population parameters lie within some range. Generally, the accepted confidence for scientific studies is 95%.</p><p><strong>2.2 Hypothesis testing</strong></p><p>Hypothesis testing is used when there is a need to decide if some population values can be ruled out based on the result of the sampling. A hypothesis is a statement about the population. Hypothesis testing determines if there is enough evidence in the data to decide whether it is false." +
            " What is tested is called a null hypothesis, for example that the drug has no effect on the recovery from a disease. To achieve that, the probability is calculated that the data supports the null hypothesis, which is called p-value. The smaller the p-value, the stronger the evidence against a null hypothesis. </p><p><strong>2.3 Decision theory</strong></p><p>Decision theory attempts to combine the sample information with the other relevant aspects of the problem and make the best decision. Relevant information may include the consequences of a decision and a prior information that is available from sources other than the sample data. For example, a drug company may consider the decision about marketing a new painkiller. The ultimate decision will be whether to make a drug or not, including estimation of potential price, demand and profits.</p><p><strong>3. Frequentist vs Bayesians</strong></p><p>The basic definition of probability divides the statistics discipline into two distinct camps: frequentists and bayesians. A simple statement, such as \"the probability that the coin lands heads is 1/2\" can be viewed in very different ways." +
            " The frequentist will consider the following: if the experiment is repeated many times, the ratio of heads and tails will approach 1:1. So the probability is the long-run expected frequency. The bayesian will consider probability to be a measure of one's belief in the outcome.</p><p>In other words, frequentist does not know which way the world is. Also, since the data is finite, he can not tell exactly which way it is. So he will list the possibilities and see which ones are ruled out by the data. A bayesian also does not know which way the world is. He collects the finite data and compares how probable are different states of the world based on this data.</p><p>In some contexts frequentists and bayesians can coexist, but in some they are deeply in conflict. For example, to assign the numerical probability to the existence of life on Mars, we’ll have to drop the frequentist approach, because in frequentist point of view probability is something that’s determined in a lengthy series of trials.</p>" +
            "<p>This essay is written in terms of the frequentist approach.</p><p><strong>4. Likelihood and Maximum Likelihood</strong></p><p>Likelihood and probability are used as synonyms in everyday language, but from statistical point of view they are very different concepts. For example, the question about probability could be \"what is the probability of getting two heads in a row\". There is a parameter (P(heads)) and we estimate the probability of a sample given this parameter. The question about likelihood would be of a somewhat reversed direction. Is the coin fair? To what extent does the sample support the hypothesis that P(heads) = 0.5? We start with the observation and make inference about the parameter. In this example, the maximum likelihood of the coin being unfair is 1 as there is no data yet to support the \"fair\" hypothesis, while the probability of two head in a row is 0.5x0.5 = 0.25.</p><p>The likelihood function is defined as (1)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_1.png\" alt=\"Equation 1\" /></div>" +
            "<p>and is the joint probability of observing the data. The maximum likelihood is the estimate of a parameter that maximises the probability of observing the data given a specific model for the data.</p><p>Continuing the example with coin tossing, the model that describes the probability of observing head for a coin flip is called Bernoulli distribution. It has the form (2)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_2.png\" alt=\"Equation 2\" /></div>" +
            "<p>where <i>p</i> is the probability of heads and x<sub>i</sub> is the outcome of the <i>i</i>th coin flip.</p><p>If the likelihood function is applied to the Bernoulli distribution, the likelihood function becomes (3).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_3.png\" alt=\"Equation 3\" /></div>" +
            "<p>To simplify the equation, the logarithm of both sides can be taken, which does not change the value of the <i>p</i> for which the function is maximized (4).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_4.png\" alt=\"Equation 4\" /></div>" +
            "<p>Figure 1 shows the plots of likelihood as function of probability. As expected, the higher the proportion of one of the two outcomes, the more likely it is that the coin is not fair.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Plot_of_likelihood.png\" alt=\"Plot of likelihood\" /></div>" +
            "<p align=\"center\">Figure 1 - Plots of likelihood as function of probability</p><p>The maximum likelihood as described above can also be determined analytically by taking the derivative of the likelihood function with respect to <i>p</i> and finding where the slope is zero. The maximum is found at (5).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_5.png\" alt=\"Equation 5\" /></div>" +
            "<p>which is just the proportion of heads observed in the experiment.</p><p><strong>5. Regression</strong></p><p>The simplest biological models are based on the concept of correlation. Correlation is observed when a change in one variable is observed together with the change in one or more other variables. For example, when the amount of calories consumed daily changes, other variables may change such as body weight or body fat percentage. Correlation is a measure of the relationship between these variables. It is important to keep in mind that a change in one of the variables does not necessarily cause the change in another. Both changes may, for example, be caused by some other, yet unknown, variable." +
            " For example, the length of the foot and the length of the palm are likely to correlate - people with large feet generally have large palms. But that does not mean that having large feet is caused by large palms, or the other way around. It is more likely that the overall body height is what causes the change in both variables.</p><p>Regression is a term that includes a number of different techniques that analyse the variables that are correlated and attempt to explore the relationship between those variables and the strength of correlation. The results may be used in developing models for prediction and forecasting.</p><p>For the regression analysis to be valid, some assumptions have to be satisfied:</p><ul><li>the sample is representative of the whole population</li><li>the error is a random variable, so errors are independent of each other</li><li>the errors are normally distributed</li><li>the errors are not correlated</li><li>the predictors, if there are more than one, are linearly independent</li></ul><p>In the following discussion of linear and non-linear regression, the data gathered by Kuzmic et al (1996) is used." +
            " The data was gathered while studying asparatic proteinase catalysed hydrolysis of a fluorogenic peptide. The data is presented in Table 1.</p><table border=\"1\"><tr><th>[S],μM</th><th>V<sub>0<sub></th></tr><tr><td>0.66</td><td>0.0611</td></tr><tr><td>1</td><td>0.0870</td></tr><tr><td>1.5</td><td>0.1148</td></tr><tr><td>3</td><td>0.1407</td></tr><tr><td>4</td><td>0.1685</td></tr><tr><td>6</td><td>0.1796</td></tr></table><strong><p class=\"align=\"center\">Table 1. Experimental data</p></strong><p><strong>5.1 Linear Regression</strong></p><p>The simplest form of regression is linear regression. It assumes that correlation between variables can be described by the equation <i>y=ax+b</i>, where <i>x</i> and <i>y</i> are the values of the variables. In this case, the relationship between variables can be plotted as a straight line. If the prediction about the linear nature of correlation is correct, and if the line is chosen well enough, the plotted values of variables will be located close to the \"ideal\" regression line." +
            " The problems here are first, to define the \"closeness\" of a variable to the predicted line and, second, to formulate a way to choose the line that will be the closest to all plotted values because there are an infinite number of possible lines and visual estimation is not at all precise enough.</p><p>The “closeness” is defined as the square of the vertical distance from the point to the regression line. The absolute value of the distance can not be used because it can be demonstrated that for any slope of the line it is possible to find such line that the absolute distances from points to the line, positive and negative, will cancel each other. Therefore, this does not solve the problem of finding a unique solution. If squared distance is used, however, the best line will go in the middle of two points, because the value of <i>a<sup>2</sup> + b<sup>2</sup></i> is smallest when <i>a = b</i>.</p><p>Now that the value of the total squared error, which is the sum of squared distances from all points, is known, it is possible to choose which of the lines gives better fit to the data." +
            " The final task is to derive a method to predict which line will be the best fit.</p><p>The least squares estimates of slope and intercept are obtained as follows:</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_6.png\" alt=\"Equation 6\" /></div>" +
            "<p>and</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_7.png\" alt=\"Equation 7\" /></div>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_8.png\" alt=\"Equation 8\" /></div>" +
            "<p>and</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_9.png\" alt=\"Equation 9\" /></div>" +
            "<p>Or <i>S<sub>xy</sub></i> is the sum of <i>x</i> deviations times the sum of <i>y</i> deviations and <i>S<sub>xx</sub></i> is the sum of <i>x</i> deviations squared. Values of <i>a</i> and <i>b</i> are called the least squares estimates of slope and intercept.</p>" +
            "<p>As an example, it is possible to apply linear regression to the data from Table 1. That makes no practical sense since it is known beforehand that the correlation is not linear and is done only for illustration.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_10.png\" alt=\"Equation 10\" /></div>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_11.png\" alt=\"Equation 11\" /></div>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_12.png\" alt=\"Equation 12\" /></div>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_13.png\" alt=\"Equation 13\" /></div>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_14.png\" alt=\"Equation 14\" /></div>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_15.png\" alt=\"Equation 15\" /></div>" +
            "<p>The data and the regression line can be plotted using the following R script</p><pre class=\"brush: cpp\">" +
            @"conc<-c(0.66,1,1.5,3,4,6)
            rate1<-c(0.0611,0.0870,0.1148,0.1407,0.1685,0.1796)
            plot(conc,rate1,lwd=2,col=""red"",xlab=""[S], micromoles"",ylab=""V0"")
            par(new=TRUE)
            abline(a=0.0683,b=0.0212,col=""blue"")
            text(3, 0.12, ""regression line"", col=""blue"")" +
            "</pre><p>The results were presented in Figure 2.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_R_Plot.png\" alt=\"R Plot\" /></div>" +
            "<p align=\"center\">Figure 2 - Linear regression against data from Table 1.</p><p>A null hypothesis can be examined, which states that <i>V<sub>0</sub></i> and <i>S</i> have no correlation. To achieve this, the Excel regression analysis was applied to determine the values of the standard error and the <i>p</i>-values. The result was presented in Figure 2.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Summary_output.png\" alt=\"Summary output\" /></div>" +
            "<p>Using the Excel function TINV(5%, 4) where 4 is the number of degrees of freedom and 5% means the 95% confidence, the value of the <i>t</i> statistic is 2.776. It is less that the critical value of 5.428, which allows to reject the null hypothesis and conclude that <i>V<sub>0</sub></i> correlates with <i>S</i>. This does not mean, of course, that the linear regression describes the correlation in the best way – there may exist a non-linear function that gives a better fit.<p></p>Another parameter describing the linear correlation is the correlation coefficient. It is a measure of the strength of the relationship of two variables and is defined as</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_16.png\" alt=\"Equation 16\" /></div>" +
            "<p>Applying to the sample data,</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_17.png\" alt=\"Equation 17\" /></div>" +
            "<p>and</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_18.png\" alt=\"Equation 18\" /></div>" +
            "<p>The value of <i>r</i> is a number between -1 and 1, and the closer <i>r</i> is to 1, the stronger is the correlation, meaning that the values lie closer to the regression line. The value of <i>r=0.9426</i> indicates that correlation is very strong and the linear regression produces a line that fits the data well." +
            " The lesson here is that it is easy to mistake a non-linear for a linear especially if there was no prior information about the nature of the relationship and the values are only measured in a limited interval.</p><p><strong>5.2 Non-Linear Regression</strong></p><p>Linear regression is a fairly simple technique and gives good results when the change in one variable has a constant influence on another. However, in biological and many other processes this is not always the case. As a simple example, as the length of a body increases, the mass increases too. But a specie which body length doubles will not double its mass - the increase in mass is likely to be greater than by the factor of two. To determine the nature of the relationship between variables when linear dependence does not apply, non-linear regression methods are used. Generally, there is no analytical solution for the non-linear least squares method.</p><p>In some cases, the non-linear functions can be transformed to the linear form. Consider the non-linear model of enzyme kinetics, the Michaelis-Menten equation (11)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_19.png\" alt=\"Equation 19\" /></div>" +
            "<p>The model can be transformed the following way:</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_20.png\" alt=\"Equation 20\" /></div>" +
            "<p>Considering that the <i>K<sub>m</sub></i> and <i>V<sub>max</sub></i> are constants, the equation is now in the linear form of <i>y=ax+b</i>, where <i>y=1/V</i>, <i>a=<i>K<sub>m</sub></i>/<i>V<sub>max</sub></i></i> and <i>b=1/<i>V<sub>max</sub></i></i>." +
            " The graphical representation of the function is known as Lineweaver-Burk plot and is used for the estimation of the <i>K<sub>m</sub></i> and <i>V<sub>max</sub></i> parameters. It is, however, very error prone because the <i>y</i>-axis takes a reciprocal of reaction rates and small measurement errors are increased.</p><p>When the analytical solution for the non-linear function does not exist, numerical methods are used. The algorithms behind these methods generally require an estimate for the parameter of interest, which should be reasonable to make sure the result is correct. In R language, <i>nls</i> function is used to determine nonlinear least-squares estimates of the parameters of a nonlinear model. To apply the function, it would be reasonable to first use the Lineweaver-Burk plot for an estimate of the parameters and then to use the results as an input for the <i>nls</i> function.</p><p>The reciprocal values were produced and the Lineweaver-Burk plot was constructed using the data from Table 1. " +
            "Next, the least squares regression was applied to the plot of reciprocals to establish the values of <i>K<sub>m</sub></i> and <i>V<sub>max</sub></i>. This was achieved by the following R script</p><pre class=\"brush: cpp\">" +
            @"concLB<-1/conc
            rate1LB<-1/rate1
            fit<-lm(rate1LB~concLB)
            fit" +
            "</pre><p>The script produced the following output.</p><pre class=\"brush: cpp\">" +
            @"Call:
            lm(formula = rate1LB ~ concLB)

            Coefficients:
            (Intercept)       concLB  
                  4.051        7.853  " +
            "</pre><p>The results were plotted by the following R script and are presented in Figure 3.</p><pre class=\"brush: cpp\">" +
            @"plot(concLB,rate1LB,ylim=range(c(rate1LB)),lwd=2,col=""red"",xlab=""1/[S], 1/micromoles"",ylab=""1/V0"")
            par(new=TRUE)
            abline(a=4.051,b=7.853,col=""blue"")
            text(1, 10, ""regression line"", col=""blue"")" +
            "</pre>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_R_Plot_2.png\" alt=\"R Plot 2\" /></div>" +
            "<p align=\"center\">Figure 3-Using Lineweaver-Burk plot to estimate Michaelis-Menten parameters</p><p>The output was used to calculate the estimates for <i>K<sub>m</sub></i> and <i>V<sub>max</sub></i>.</p><i>1/V<sub>max</sub> = 4.051 + 7.853*(1/K<sub>m</sub>)</i><br/><i>V<sub>max</sub> = 1/4.051 = 0.2469</i><br/><i>-7.853*(1/K<sub>m</sub>) = 4.051</i><br/><i>-(1/K<sub>m</sub>)=0.5159</i><br/><i>K<sub>m</sub> = 1.9384</i><br/><p>Now that the reasonable estimates are calculated, it is possible to use the non-linear regression to fit Michaelis-Menten function. This is achieved by the following R script.</p><pre class=\"brush: cpp\">" +
            @"df<-data.frame(conc, rate1)   
            nlsfit <- nls(rate1~Vm*conc/(K+conc),data=df, start=list(K=1.9384, Vm=0.2469))
            summary(nlsfit)" + "</pre><p>The script provides the following output</p><pre class=\"brush: cpp\">" +
            @"Formula: rate1 ~ Vm * conc/(K + conc)

            Parameters:
               Estimate Std. Error t value Pr(>|t|)    
            K    1.6842     0.2141   7.868  0.00141 ** 
            Vm   0.2315     0.0112  20.664 3.24e-05 ***
            ---
            Signif. codes:  0 *** 0.001 ** 0.01 * 0.05 . 0.1   1 

            Residual standard error: 0.005917 on 4 degrees of freedom

            Number of iterations to convergence: 3 
            Achieved convergence tolerance: 2.895e-06" +
            "</pre><p>Alternatively, the R language contains a number of ‘self-starting’ models, which can be used without the initial estimates for the parameters. The Michaelis-Menten model is represented by SSmicmen function and can be used as in the following R script</p><pre class=\"brush: cpp\">" +
            @"model<-nls(rate1~SSmicmen(conc,a,b))
            summary(model)

            The script provides the following output

            Formula: rate1 ~ SSmicmen(conc, a, b)

            Parameters:
              Estimate Std. Error t value Pr(>|t|)    
            a   0.2315     0.0112  20.664 3.24e-05 ***
            b   1.6842     0.2141   7.868  0.00141 ** 
            ---
            Signif. codes:  0 *** 0.001 ** 0.01 * 0.05 . 0.1   1 

            Residual standard error: 0.005917 on 4 degrees of freedom

            Number of iterations to convergence: 0 
            Achieved convergence tolerance: 2.637e-06" +
            "</pre><p>In this case, the results were identical for the <i>nls</i> function and the SSmicmen function. This probably means that the initial estimates used in the <i>nls</i> function were reasonable. Lastly, the parameters identified by nonlinear regression can be used to plot the resulting function and compare it with experimental data.</p><p>The following R script will generate 100 points on the curve predicted by the values of <i>K<sub>m</sub></i> and <i>V<sub>max</sub></i> that were identified by the nonlinear least squares method and plot them against the experimental data.</p><pre class=\"brush: cpp\">" +
            @"plot(conc,rate1,lwd=2,col=""red"",xlab=""[S], micromoles"",ylab=""V0"")
            par(new=TRUE)
            Vm <- 0.2315
            K <- 1.6842
            x <- seq(0, 6, length=100)
            y <- (Vm*x)/(K+x)
            lines(x, y, lty=""dotted"", col=""blue"")
            text(3, 0.13, ""regression line"", col=""blue"")" +
            "</pre><p>The output is presented in Figure 4.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_R_Plot_3.png\" alt=\"R Plot 3\" /></div>" +
            "<p align=\"center\">Figure 4-Fitted curve plotted against experimental data.</p><p>To measure how well the fitted curve fits the data, a number of tests may be used. One of them is the <i>F-test</i>, which measures a null hypothesis that a predictor (in this case, <i>[S]</i>, has no value in predicting <i>V<sub>0</sub></i>. <i>F</i> is defined as (13)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_21.png\" alt=\"Equation 21\" /></div>" +
            "<p>where " +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_22.png\" alt=\"Equation 22\" /></div>" +
            "  is the <i>i</i>th predicted value, " +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_23.png\" alt=\"Equation 23\" /></div>" +
            " is the <i>i</i>th observed value, and  " +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_24.png\" alt=\"Equation 24\" /></div> is the mean. Specialized tables exist to obtain the critical values of <i>F</i> given the sample size and the required confidence percentage." +
            " When the <i>F</i> test is applied to two models, the test measures the probability that they have the same variance.</p><p>Another test is the Akaike information criterion (AIC). It does not test the null hypothesis and, therefore, does not tell how well the model fits the data. It estimates how much information is lost when the attempt is made to fit the data to the model. In practice, it is used to select between several model the one that has the highest probability of being correct. If there are more than one model for which the AIC value is the same or very close, the best model may be a weighted sum of those models. AIC is defined as (14)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/04082012_Equation_25.png\" alt=\"Equation 25\" /></div>" +
            "<p>where <i>k</i> is the number of parameters in the model, and <i>L</i> is the maximised value of the likelihood function for the model.</p><p><strong>References:</strong></p>Aitken M, Broadhurst B, Hladky S, <i>Mathematics for Biological Scientists</i> 2010, Garland Science, NY and London<br/>" +
            "Crawley, M, <i>The R Book</i>, Wiley, 2007<br/>Kuzmic P, Peranteau A, Garcia-Echeverria C, Rich D, <i>Mechanical Effects on the Kinetics of the HIV Proteinase Deactivation</i>, Biochemical and Biophysical Research Communications 221, 313-317 (1996)<br/>Ott R, Longnecker M, <i>An Introduction to Statistical Methods and Data Analysis</i>, Brooks/Cole, 2010<br/>Trosset M, <i>An Introduction to Statistical Inference and its Applications With R</i>, Chapnam and Hall, 2009<br/><i>Mathematics for Metabolic Modelling - Course Materials</i> 2012, University of Manchester, UK<br/>";
        public const string content_04082012_k = "bioinformatics biology statistical inference";
        public const string content_04082012_d = "A brief tutorial on inferential statistics";

        //"A Tutorial on Probability and Exponential Distribution"
        public const string content_01082012_b = "<i><u>Probability</u></i><p>Probability is defined as a chance that a certain outcome will occur. In simple terms, it can be described as the chance, likelihood or odds of some event happening. Probability is measured as the number between zero and one. Zero is absolute certainty that the event will not happen, so it can be said that the probability of the Sun rising in the west is zero. One is the opposite, absolute certainty that the event will happen, such as the Sun rising in the morning. Probability can be written down as a number or a percentage. So the probability of tails when flipping a fair coin is either 0.5 or 50%. In mathematical notation, a random variable that describes a coin toss is defined as (1).</p><i><u>Random variables</u></i>";
        public const string content_01082012_r = "<p>A random variable is an important concept in probability. A random variable maps the probability space to a measurable space, therefore it is a function. Each argument, which is a real number, is mapped to an outcome.  There are two types of random variables: discrete and continuous.  A discrete random variable has a countable amount of possible values, such as the number of times a coin turns up heads or the number of accidents at an intersection during a year. A continuous random variable has an infinite number of possible values, such as the length of a phone call. Even though it can be measured, the precision might be to a millionth of a second and the number of possible lengths is so large that it cannot realistically be counted. " +
            "Random variables are used when describing probability models. In mathematical notation, a random variable that describes a coin toss is defined as (1).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Distribution.png\" alt=\"Distribution\" /></div>" +
            "<i><u>Probability density function</u></i><p>Each random variable has an associated probability distribution. For a discrete random variable this distribution is called the probability mass function (pmf) and for the continuous random variable – the probability distribution function (pdf)." +
            " In simple terms, it can be described as the shape of the distribution. It tells how densely or tightly the probability is packed for any point x. The key property of all probability distributions is that the total area under the pdf curve is always equal to one. To understand why, consider that the pdf represents the entire sample space and the event is guaranteed to happen somewhere in that space. Therefore the total probability over the sample space is one. The area below the pdf function to the left of the value <i>x</i> is equal to the probability of the random variable being less than the given <i>x</i>. As an example of the pdf consider the plot generated by the following R script:</p><pre class=\"brush: cpp\">" +
            @"x=seq(-4,4,length=200)
            y=dnorm(x)
            plot(x,y,type=""l"", lwd=2, col=""blue"")
            x=seq(-1,1,length=100)
            y=dnorm(x)
            polygon(c(-1,x,1),c(0,y,0),col=""gray"")" +
            "</pre><p>The script above generates the following plot and the probability that random variable <i>x</i> takes the value between -1 and 1 is equal to the greyed area under the curve.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Distribution_Plot.png\" alt=\"Distribution Plot\" /></div>" +
            "<p align=\"center\">Figure 1 - An example of probability distribution</p><p>From the mathematical perspective, to find the area under the curve over a range the pdf is integrated over that range. " +
            "Equation (2) calculates the probability of the random variable <i>x</i> being between values <i>a</i> and <i>b</i>.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Probability.png\" alt=\"Probability\" /></div>" +
            "<i><u>Cumulative distribution function</u></i><p>Cumulative distribution function (cdf) is the total probability of a random variable taking a value less than <i>x</i>. It is useful for finding probabilities of being less than, greater than or between two values of <i>x</i>.</p>" +
            "<i><u>Probability models</u></i><p>Probability models are used when it is necessary to describe a large number of individual events, where each event follows the same pattern, for example how long a phone call to a call centre is likely to last or how tall a specimen of a certain species is likely to grow. Probability models provide the formulas to describe probabilities.</p><i><u>Uniform random variable and distribution model</u></i><p>A uniform random variable is defined when an event is equally likely to happen on any given value in a finite interval (a, b). For example, when looking for a short in a 1m long piece of a wire, the probability to find it in the first or last 10cm is the same, and equals to 0.1 or 10%. " +
            "The pdf for the random variable that has uniform distribution can be defined as (3).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Function.png\" alt=\"Function\" /></div>" +
            "<p>The uniform distribution is the most basic continuous random variable: all the values of a probability density function are the same, which means that the occurrence of a random variable within an interval of fixed length is independent of the location of the interval." +
            " It is also known as a rectangular distribution, because the area under the curve of the pdf is rectangular in shape, and the pdf itself is a straight horizontal line. Real-life examples may include composition samples from perfect mixtures, arrival times of requests on a web server or just a random number generator. An example of discrete uniform distribution model can be demonstrated by plotting the results of a simple 6-sided die roll, using the following R script:</p><pre class=\"brush: cpp\">" +
            @"numcases <- 10000                           #number of rolls
            min <- 1                                  #minimum and maximum values
            max <- 6
            x <- as.integer(runif(numcases,min,max+1) )        
            par(mfrow=c(2,1))                        
            hist(x,main=paste( numcases,"" rolls of a single die""),breaks=seq(min-.5,max+.5,1))" +
            "</pre>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Uniform_distribution.png\" alt=\"Uniform distribution\" /></div>" +
            "<p align=\"center\">Figure 2 - Uniform distribution model</p><i><u>Exponential distribution model</u></i><p>Another model of a continuous distribution is the exponential distribution. The exponential distribution has its name because its pdf has the shape of the exponential function." +
            " It crosses the Y-axis at some positive value called λ and then slope down to the right in a curve, decreasing towards zero as the values of random variable X increase, but never reaches zero. The amount of slope in the curve is determined by the value of λ. The exponential random variable has the pdf defined in (4).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Function_2.png\" alt=\"Function\" /></div>" +
            "<p>The cdf for the exponential distribution is defined in (5).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Function_3.png\" alt=\"Function\" /></div>" +
            "<p>An example of the exponential distribution is plotted using the R script below, using λ=2. The greyed area corresponds to the probability of <i>x</i> taking the value less than 1.</p><pre class=\"brush: cpp\">" +
            @"x=seq(0,4,length=200)
            y=dexp(x,rate=2)
            plot(x,y,type=""l"",lwd=2,col=""red"",ylab=""p"")
            x=seq(0,1,length=200)
            y=dexp(x,rate=2)
            polygon(c(0,x,1),c(0,y,0),col=""lightgray"")" +
            "</pre>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Exponential_distribution_model.png\" alt=\"Exponential distribution model\" /></div>" +
            "<p align=\"center\">Figure 3 - Exponential distribution model</p><p>The exponential distribution can be applied to describe a number of various processes. The amount of time from now until the next earthquake occurs has an exponential distribution." +
            " It also describes the length of phone calls or the amount of time the battery lasts. The amount of change in someone’s pocket or the amounts of money customers spend in the supermarket also follow an exponential distribution. It is intuitively easy to visualize, because most customers would spend a relatively small amount of money, only a small percentage would spend over $200 in one visit, and very rarely someone would spend over a thousand. Hence the probability will be highest for small amounts, and will approach zero for large amounts.</p><p>An important property of the exponential random variable is memorylessness. " +
            "If X represents a waiting time, then the probability of waiting a given length of time is not affected by the time waited already. This is described by a formula</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Probability_2.png\" alt=\"Probability\" /></div>" +
            "<p>In other words, if you have already waited a minutes, the probability of waiting another b minutes is the same as the initial probability of waiting b minutes.</p>" +
            "<p>The constant λ is the reciprocal of the mean of the exponential distribution. So, if the value of λ is large, the distribution has a small mean and quickly drops toward zero. If the value of λ is small, the mean is large and the distribution drops very slowly. This is illustrated by the following R script, which plots the distribution with λ=3 in red and λ=1 in green. The red curve drops towards the zero much faster than the green one.</p><pre class=\"brush: cpp\">" +
            @"x=seq(0,4,length=200)
            y=dexp(x,rate=3)
            x1=seq(0,4,length=200)
            y1=dexp(x1,rate=1)
            plot(x,y,type=""l"",lwd=2,col=""red"",ylab=""p"")
            lines(x1,y1,type=""l"",lwd=2,col=""green"",ylab=""p"")" +
            "</pre>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Influence_of_lambda_on_exponential_distribution.png\" alt=\"Influence of lambda on exponential distribution\" /></div>" +
            "<p align=\"center\">Figure 4 - Influence of λ on exponential distribution</p><p>The expected value of an exponential distribution is equal to 1/λ.</p><p>An example of applying the properties of the exponential distribution to a problem:</p>" +
            "<p>Suppose that the amount a person waits in line has a mean of 10 minutes, exponentially distributed with λ=1/10. What is the probability that a person will spend more than 15 minutes in a line? What is the probability that a person will spend more than 15 minutes in a line, if he is still in a line after 10 minutes?</p><p>Answer:</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Probability_3.png\" alt=\"Probability\" /></div></a>" +
            "</div><p>Exponential random variates can be generated from the uniform random variates according to (7).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Probability_4.png\" alt=\"Probability\" /></div>" +
            "<p>To visually confirm this property of the exponential distribution, the following R script first generates uniform random variates and then applies (7) to each of them to calculate the value of <i>x</i>, which is then plotted on the graph in Figure 4.</p><pre class=\"brush: cpp\">" +
            @"n<-100
            lambda <- 1
            UnifRandVar <- runif(n, min=0, max=100)
            ExpRandVar <- -(1/lambda)*log(UnifRandVar)
            plot(UnifRandVar, ExpRandVar, col=""blue"", xlab=""Uniform Random Variates"", ylab=""Exponential Random Variates"", main=paste(""Plot of "", length(UnifRandVar), "" exponential variates given lambda="", lambda), col.main=""red"")" +
            "</pre>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/01082012_Exponential_variates_generated_from_uniform_variable.png\" alt=\"Exponential variates generated from uniform variable\" /></div>" +
            "<p align=\"center\">Figure 5 - Exponential variates generated from uniform variable</p><p><strong>References:</strong></p>Aitken M, Broadhurst B, Hladky S, <i>Mathematics for Biological Scientists</i> 2010, Garland Science, NY and London<br/>Graham A, <i>Statistics: An Introduction</i> 1995, Hodder & Stoughton Educational, London, UK<br/>Press W, Teukolsky S, Vetterling W, Flannery B, <i>Numerical Recipes: The Art of Scientific Computing</i>, 3rd edition 2007, Cambridge University Press, UK<br/>Rumsey D, <i>Probability for Dummies</i> 2006, Wiley Publishing, Hoboken, NJ, USA.<br/><i>Mathematics for Metabolic Modelling</i> - Course Materials 2012, University of Manchester, UK";
        public const string content_01082012_d = "A Tutorial on Probability and Exponential Distribution";
        public const string content_01082012_k = "bioinformatics biology probability exponential distribution";

        //"Estimating Michaelis-Menten Parameters"
        public const string content_15052012_b = "<h2>1. Introduction</h2><p>The asparatic proteinase from HIV is a target for antiviral drug design.  Kuzmic et al (1996) studied the influence of mechanical stirring on the process of asparatic proteinase catalysed hydrolysis of a fluorogenic peptide. The kinetics were measured for the two reactions types, one with mechanical stirring and one without, under otherwise identical conditions. Initial velocities from both sets of reactions were plotted at initial substrate concentrations of 6, 4, 3, 1.5, 1 and 0.66 micromoles. Kuzmic et al (1996) did not include the raw data into the article, but the data was presented in Figure 1.</p>";
        public const string content_15052012_r =
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/15052012_Raw_data_used_in_the_exercise.png\" alt=\"Raw data used in the exercise\" /></div>" +
            "<p align=\"center\"><strong>Figure 1. Raw data used in the exercise</strong></p><p>For the purpose of this exercise, the raw data was visually translated from the graph into the numeric values. The data then was plotted using the following <strong>R</strong> script</p><pre class=\"brush: cpp\">" +
            @"conc&lt;-c(0.66,1,1.5,3,4,6)
            rate1&lt;-c(0.0611,0.0870,0.1,0.1407,0.1685,0.1796)
            rate2&lt;-c(0.0685,0.0944,0.1148,0.1592,0.1796,0.1907)

            plot(conc,rate1,ylim=range(c(rate1,rate2)),lwd=2,col=""red"",xlab=""[S], micromoles"",ylab=""V0"")
            par(new=TRUE)
            plot(conc,rate2,ylim=range(c(rate1,rate2)),lwd=2,col=""green"",axes=FALSE,xlab="""",ylab="""")" +
            "</pre>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/15052012_Raw_data_plotted_with_R.png\" alt=\"Raw data plotted with R\" /></div>" +
            "<strong><p align=\"center\">Figure 2. Raw data plotted with R</p></strong><h2>2. Using the Lineweaver-Burk plot</h2><p>Next, the reciprocal values were produced and the Lineweaver-Burk plot was constructed and plotted using the following <strong>R</strong> script</p><pre class=\"brush: cpp\">" +
            @"concLB&lt;-1/conc
            rate1LB&lt;-1/rate1
            rate2LB&lt;-1/rate2
            plot(concLB,rate1LB,ylim=range(c(rate1LB,rate2LB)),lwd=2,col=""red"",xlab=""1/[S]"",ylab=""1/V0"")
            par(new=TRUE)
            plot(concLB,rate2LB,ylim=range(c(rate1LB,rate2LB)),lwd=2,col=""green"",xlab="",ylab="")" +
            "</pre><strong>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/15052012_Lineweaver-Burk_plot_with_R.png\" alt=\"Lineweaver-Burk plot with R\" /></div>" +
            "<p align=\"center\">Figure 3. Lineweaver-Burk plot with R</p></strong><p>Next, the least squares regression was applied to the plot of reciprocals to establish the values of K<sub>m</sub> and V<sub>max</sub></p><pre class=\"brush: cpp\">" +
            @"fit&lt;-lm(rate1LB~concLB)
            fit

            Call:
            lm(formula = rate1LB ~ concLB)

            Coefficients:
            (Intercept)       concLB  
                  4.050        7.626" +
            "</pre><p>From the results of the script, the regression line for the data gathered in the absence of stirring is described by the following equation<br>1/ V<sub>max</sub> = 4.050 + 7.626*(1/ K<sub>m</sub>)<br>V<sub>max</sub> = 1/4.050 = 0.2469<br>-7.626*(1/ K<sub>m</sub>) = 4.050<br>-(1/ K<sub>m</sub>)=0.5311<br>K<sub>m</sub> = 1.8829</p><p>Similarly, the following script was applied to the second set of data</p><pre class=\"brush: cpp\">" +
            @"fit&lt;-lm(rate2LB~concLB)
            fit

            Call:
            lm(formula = rate2LB ~ concLB)

            Coefficients:
            (Intercept)       concLB  
                  3.957        6.932  
            Call:
            lm(formula = rate2LB ~ concLB)

            Coefficients:
            (Intercept)       concLB  
                  4.166        7.170" +
            "</pre><p>The regression line was described by the following equation.<br>1/ V<sub>max</sub> = 4.166 + 7.170*(1/ K<sub>m</sub>), from which<br>V<sub>max</sub> = 0.24, K<sub>m</sub> = 1.7212</p><h2>3. Using the Hanes-Woolf plot</h2><p>The Lineweaver-Burk plot is prone to errors as small errors in reaction rate measurement increase the reciprocal. Among alternative linear forms is the Hanes-Woolf plot where the ratio of the substrate concentration to the reaction velocity is plotted against substrate concentration." +
            " The data was used to plot the Hanes-Woolf plot using the following <strong>R</strong> script</p><pre class=\"brush: cpp\">" +
            @"rate1HW&lt;-conc/rate1
            rate2HW&lt;-conc/rate2
            plot(conc,rate1HW,ylim=range(c(rate1HW,rate2HW)),lwd=2,col=""red"",xlab=""[S]"",ylab=""[S]/V0"")
            par(new=TRUE)
            plot(conc,rate2HW,ylim=range(c(rate1HW,rate2HW)),lwd=2,col=""green"",xlab="""",ylab="""")" +
            "</pre><p>The least squares regression was applied</p><pre class=\"brush: cpp\">" +
            @"fit&lt;-lm(rate1HW~conc)
            fit

            Call:
            lm(formula = rate1HW ~ conc)

            Coefficients:
            (Intercept)         conc  
                  8.005        4.191" +
            "</pre><p>The regression line is described by the following equation<br>(S/v) = 8.005 + 4.191*S<br>K<sub>m</sub> = 8.005/4.191 = 1.91<br>K<sub>m</sub> / V<sub>max</sub> = 8.005<br>V<sub>max</sub> = 1.91/8.005 = 0.2386</p><p>Similar script was used to process the data taken in the presence of stirring.</p><pre class=\"brush: cpp\">" +
            @"fit&lt;-lm(rate2HW~conc)
            fit

            Call:
            lm(formula = rate2HW ~ conc)

            Coefficients:
            (Intercept)         conc  
                  6.726        4.054" +
            "</pre><p>The regression line is described by the following equation<br>(S/v) = 6.726 + 4.054*S<br>K<sub>m</sub> = 1.659, V<sub>max</sub> = 0.2467</p><h2>4. Using the R language package</h2><p>Finally, the non-linear self-starting Michaelis-Menten model, which is part of the <strong>R</strong> language, was used to estimate the values of V<sub>max</sub>" +
            " and K<sub>m</sub> in the absence of stirring using the following <strong>R</strong> script</p><pre class=\"brush: cpp\">" +
            @"model&lt;nls(rate1~SSmicmen(conc,a,b))
            summary(model)

            and providing the following output

            Formula: rate1 ~ SSmicmen(conc, a, b)

            Parameters:
              Estimate Std. Error t value Pr(&gt;|t|)    
            a  0.23953    0.01188  20.166 3.57e-05 ***
            b  1.92898    0.23804   8.104  0.00126 ** 
            ---
            Signif. codes:  0 *** 0.001 ** 0.01 * 0.05 . 0.1   1 

            Residual standard error: 0.005621 on 4 degrees of freedom

            Number of iterations to convergence: 0 
            Achieved convergence tolerance: 1.244e-06 " +
            "</pre><p>Which estimated V<sub>max</sub> = 0.23953 and K<sub>m</sub> =1.92898</p><p>Similar results for the reaction with stirring were</p><pre class=\"brush: cpp\">" +
            @"model&lt;-nls(rate2~SSmicmen(conc,a,b))
            summary(model)

            Formula: rate2 ~ SSmicmen(conc, a, b)

            Parameters:
              Estimate Std. Error t value Pr(&gt;|t|)    
            a 0.248409   0.006281   39.55 2.44e-06 ***
            b 1.682884   0.111784   15.05 0.000113 ***
            ---
            Signif. codes:  0 *** 0.001 ** 0.01 * 0.05 . 0.1   1 

            Residual standard error: 0.003319 on 4 degrees of freedom

            Number of iterations to convergence: 0 
            Achieved convergence tolerance: 2.261e-06" +
            "</pre><p>Which estimated V<sub>max</sub> = 0.248409 and K<sub>m</sub> =1.682884</p><h2>5. Conclusion</h2><p>For reference, Kuzmic et al (1996) estimated the best-fit values of kinetic constants as K<sub>m</sub> (1.71 ± 0.28) &mu;M, and V<sub>max</sub> (0.235 ± 0.015) abstract units/s in the absence of stirring, and K<sub>m</sub> (2.31 ± 0.24) &mu;M, and V<sub>max</sub> (0.279 ± 0.012) with stirring. The results obtained by different methods were summarised in Table 1.</p>" +
            "<table border=\"1\"><tr><th></th><th>L-B Plot</th><th>H-W Plot</th><th>SSmicmen</th><th>Kuzmic et al</th></tr><tr><td>No Stirring, K<sub>m</sub>, &mu;M</td><td>1.8829</td><td>1.91</td><td>1.92898</td><td>1.71 ± 0.28</td></tr><tr><td>No Stirring, V<sub>max</sub></td><td>0.2469</td><td>0.2386</td><td>0.23953</td><td>0.235 ± 0.015</td></tr><tr><td>Stirring, K<sub>m</sub>, &mu;M</td><td>1.7212</td><td>1.659</td><td>1.682884</td><td>2.31 ± 0.24</td></tr><tr><td>Stirring, " +
            "V<sub>max</sub></td><td>0.24</td><td>0.2467</td><td>0.248409</td><td>0.279 ± 0.012</td></tr></table><strong><p class=\"align=\"center\">Table 1. Michaelis-Menten parameters estimated by various methods</p></strong><h2>References:</h2><p>Crawley, M, <i>The R Book</i>, Wiley, 2007</p><p>Kuzmic P, Peranteau A, Garcia-Echeverria C, Rich D, <i>Mechanical Effects on the Kinetics of the HIV Proteinase Deactivation</i>, Biochemical and Biophysical Research Communications 221, 313-317 (1996)</p>";
        public const string content_15052012_k = "bioinformatics biology Estimating Michaelis-Menten Parameters";
        public const string content_15052012_d = "Estimating Michaelis-Menten Parameters";


        //"Building a model for the mouse response to Trypanosoma Congolense using jActiveModules and BiNGO"
        public const string content_23022012_b = "<p><strong>1. Introduction</strong></p><p>African trypanosomes are protozoan parasites that cause severe diseases in human and livestock with fatal consequences unless treated. Trypanosomiasis caused by T. congolense and T. vivax is one of the most significant constraints on cattle production in Africa.</p>";
        public const string content_23022012_r =
            "<p>Trypanosomes are extracellular parasites that survive in the bloodstream. In cattle, anaemia is the key feature of the disease and persists after the first wave when parasite numbers have declined to low or undetectable levels. Because of the importance of the anaemia in trypanosomiasis many studies have been carried out to describe its nature and discover its causes (Noyes et al, 2009).</p><p>A mouse model may be helpful in developing understanding of the mechanisms underlying the resistance to trypanosoma." +
            " Certain strains of mice are tolerant to the disease while others are highly susceptible. Microarray experiments have been carried out on C57BL/6, BALB/c and A/J strains of mice. A large amount of data has been recorded at different time points after the infection.</p><p><strong>2. Background</strong></p><p>The microarray experiment results were provided for this project in the form of an interaction network (hereafter “mouse liver” network) including only those genes for which there is evidence of expression in liver." +
            " The data was provided in the form of xgmml file. The data showing the changes in gene expression between day 0 and day 7 post-infection was measured on samples from liver tissue and was provided in the form of the pvals file.</p><p><strong>3. Aims</strong></p><p>The aim of the project was to examine the data provided at the pathway level. A possible model was developed for the mouse response at peak parasitaemia (day 7 after infection).</p><p><strong>4. Materials and methods</strong></p><p>The following software was used in the project:<br/>" +
            "<ul><li>Cytoscape version 2.8.2</li><li>Network Analysis plugin</li><li>Advanced Network Merge plugin</li><li>jActiveModules plugin</li></ul></p><p>The following data was provided:<br/><ul><li>Mouseliver.xgmml : the interaction network file</li><li>Abc07.pvals : the gene expression file</li></ul></p><p>The data was analysed using the software listed above following the protocol by Cline et al (2007).</p><p><strong>4.1. Network parameters</strong></p><p>The mouse liver network was loaded into Cytoscape. The network contained 3,531 nodes and 17,195 edges (Figure 1)." +
            " The network consisted of one large connected component of 2,674 nodes and 15,639 edges and 253 smaller components not connected to the large component. The smaller components range in size from 2 to 36 nodes.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Mouse_Liver_Network.png\" alt=\"Mouse Liver Network\" /></div>" +
            "<p align=\"center\">Figure 1 - Mouse liver network.</p><p><strong>4.2. Node Degree Distribution</strong></p><p>As expected from literature, node degree distribution in a cellular network is not random, but follows a power law (Barabasi & Oltvai, 2004). The power law was fitted as follows: <strong>y = 6578x<sup>-1.918</sup></strong>. The power law explains 91.6% of the distribution, which is a very good fit (Figures 2, 3).</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Node_degree_distribution_and_power_law.png\" alt=\"Node degree distribution and power law\" /></div>" +
            "<p align=\"center\">Figure 2 - Node degree distribution and power law</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Node_degree_distribution_betweenness_centrality.png\" alt=\"Node degree distribution betweenness centrality\" /></div>" +
            "<p align=\"center\">Figure 3 - Node degree distribution</p><p>The value of betweenness centrality is normalized and therefore lies between 0 and 1.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Betweenness_centrality_in_mouse_liver_network.png\" alt=\"Betweenness centrality in mouse liver network\" /></div>" +
            "<p align=\"center\">Figure 4 - Betweenness centrality in mouse liver network</p><p><strong>4.3. Identifying Active Modules</strong></p><p>Gene expression data was imported into Cytoscape from the abc07.pvals file provided. The significance values a07sig, b07sig and c07sig were used to identify active modules within the mouse liver network using the jActiveModules plugin. The plugin identified five active modules. Two first modules, containing 185 and 234 nodes, were selected for further analysis. The Advanced Network Merge plugin was used to identify the intersection between the modules. The resulting merged network contained 143 nodes, which is a high degree of intersection.</p>" +
            "<p>The following steps were performed for each module and for the intersection network:<br/><ul><li>expression data was coloured by fold change in A/J mice</li><li>ten proteins with highest log fold values were identified</li><li>the results were presented in Tables in results section, including protein name, log fold value and whether the protein is present in module 1, module 2 and the intersection between modules</li></ul><br/>The steps were repeated for BALB/c and C57BL/6 mice strains.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Active_module_in_mouse_liver_network.png\" alt=\"Active module in mouse liver network\" /></div>" +
            "<p align=\"center\">Figure 5 - Active module identified in mouse liver network.</p><p><strong>4.4. Checking against Gene Ontology</strong></p><p>Gene ontology project provides a controlled vocabulary of terms for describing gene product characteristics and gene product annotation data. Gene Ontology for the mouse liver network was checked using the BiNGO plugin v. 2.44. The following files were downloaded from the Gene Ontology website: the full ontology file v.1.2 (gene_ontology_ext.obo) from the downloads/ontologies section and Mus musculus annotation file (gene_association) from downloads/annotations section.</p>" +
            "<p><ul><li>BiNGO plugin was started</li><li>With the whole mouse liver network being active, the first of the active modules found in 4.3 was selected. This highlighted the module nodes in the mouse liver network</li><li>The following settings were changed from default in BiNGO settings screen:</li><ul><li>Select reference set: “Use Network as Reference set”</li> <li>Select ontology file: gene_ontology_ext.obo</li><li>Select organism/annotation: gene_association</li><li>Significance level: 0.01</li></ul><li>BiNGO analysis was performed</li><li>BiNGO output in the form of the data panel and the graph was analysed and the results were investigated in the attempt to identify the gene categories that were over-represented.</li></ul></p>" +
            "<p>The steps above were repeated for the second active module.</p><p>Two categories were identified as over-represented for further analysis. The genes annotated with these categories were selected from the original mouse liver network into new networks. Each of these networks was then analysed to find the intersection between the over-represented category and the active modules identified in 4.3.</p><p><strong>5. Results</strong></p>" +
            "<p>The output from the BiNGO plugin was analysed and the genes with the highest log fold values on day 7 were presented in the tables below, broken down for mouse strains and indicating if the gene is present in module 1, module 2 and the intersection network.</p><p><table border=\"1\"><tr><td>Gene</td><td>a07exp</td><td>Module 1</td><td>Module 2</td><td>Intersection</td></tr><tr><td>Ubd</td><td>5.9678954</td><td>1</td><td>1</td><td>X</td></tr><tr><td>Gbp2</td><td>5.7735786</td><td>2</td><td>2</td><td>X</td></tr><tr><td>Ccl8</td><td>5.7155864</td><td></td><td>3</td><td></td></tr><tr><td>Gbp1</td><td>5.445365</td><td>3</td><td>4</td><td>X</td></tr><tr><td>Lgals3</td><td>5.4172534</td><td>4</td><td>5</td><td>X</td></tr>" +
            "<tr><td>Serpina3g</td><td>5.362374</td><td>5</td><td>6</td><td>X</td></tr><tr><td>Ccl6</td><td>5.1455947</td><td>6</td><td>7</td><td>X</td></tr><tr><td>Marco</td><td>5.030731</td><td>7</td><td>8</td><td>X</td></tr><tr><td>Fpr2</td><td>4.822051</td><td>8</td><td></td><td></td></tr><tr><td>Mmp13</td><td>4.6918998</td><td></td><td>9</td><td></td></tr><tr><td>Cxcl9</td><td>4.5458629</td><td>9</td><td>10</td><td>X</td></tr><tr><td>Gzmb</td><td>4.5131922</td><td>10</td><td>11</td><td>X</td></tr></table></p><p align=\"center\">Figure 6 - Genes with highest log fold values in A/J strain, day 7</p>" +
            "<p><table border=\"1\"><tr><td>Gene</td><td>b07exp</td><td>Module 1</td><td>Module 2</td><td>Intersection</td></tr><tr><td>Serpina3g</td><td>6.76103175</td><td>1</td><td>1</td><td>X</td></tr><tr><td>Gbp2</td><td>5.82087485</td><td>2</td><td>2</td><td>X</td></tr><tr><td>Gbp1</td><td>5.7275038</td><td>3</td><td>3</td><td>X</td></tr><tr><td>Fpr2</td><td>4.94588325</td><td>4</td><td></td><td></td></tr><tr><td>Lgals3</td><td>4.90982775</td><td>5</td><td>4</td><td>X</td></tr><tr><td>Cd74</td><td>4.78939395</td><td>6</td><td>5</td><td>X</td></tr><tr><td>Ly6a</td><td>4.7619165</td><td>7</td><td>6</td><td>X</td></tr><tr><td>Ccl8</td><td>4.62952825</td><td></td><td>7</td><td></td></tr><tr><td>H2-Aa</td><td>4.624156175</td><td>8</td><td>8</td><td>X</td></tr>" +
            "<tr><td>Fcgr4</td><td>4.5432714</td><td>9</td><td>9</td><td>X</td></tr><tr><td>H2-Eb1</td><td>4.4276222</td><td>10</td><td>10</td><td>X</td></tr></table></p><p align=\"center\">Figure 7 - Genes with highest log fold values in BALB/c strain, day 7</p><p><table border=\"1\"><tr><td>Gene</td><td>c07exp</td><td>Module 1</td><td>Module 2</td><td>Intersection</td></tr><tr><td>Ubd</td><td>6.4093402</td><td>1</td><td>1</td><td>X</td></tr><tr><td>Gbp2</td><td>6.2236</td><td>2</td><td>2</td><td>X</td></tr><tr><td>Serpina3g</td><td>5.1775226</td><td>3</td><td>3</td><td>X</td></tr><tr><td>Cxcl9</td><td>5.0992863</td><td>4</td><td>4</td><td>X</td></tr><tr><td>Cxcl10</td><td>4.7095646</td><td>5</td><td>5</td><td>X</td></tr>" +
            "<tr><td>Lgals3</td><td>4.6491436</td><td>6</td><td>6</td><td>X</td></tr><tr><td>Gbp1</td><td>4.2545664</td><td>7</td><td>7</td><td>X</td></tr><tr><td>Igj</td><td>4.2137042</td><td></td><td>8</td><td></td></tr><tr><td>Fpr2</td><td>4.1394768</td><td>8</td><td></td><td></td></tr><tr><td>Gzmb</td><td>3.7592078</td><td>9</td><td>9</td><td>X</td></tr><tr><td>Vim</td><td>3.7421474</td><td>10</td><td>10</td><td>X</td></tr></table></p><p align=\"center\">Figure 8 - Genes with highest log fold values in C57BL/6 strain, day 7</p><p>Graphical output from BiNGO was analysed visually. " +
            "The yellow and orange nodes represent gene ontology categories that are overrepresented at the significance level. Uncoloured nodes are not overrepresented themselves, but they are parents of overrepresented nodes further down. Some nodes could be immediately identified as most relevant – there were most intensely coloured and were located away from the centre of the network. Nodes with GO-ID 6954 (inflammatory response) and 9611 (response to wounding) were selected as relevant.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_BiNGO_output_for_active_module_1_and_nodes_with_GOID_6954_9611.png\" alt=\"BiNGO output for active module 1 and nodes with GO-ID 6954 9611\" /></div>" +
            "<p align=\"center\">Figure 9 - BiNGO output for active module 1 and nodes with GO-ID 6954, 9611</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_BiNGO_output_for_active_module_2_and_nodes_with_GOID_6954_9611.png\" alt=\"BiNGO output for active module 2 and nodes with GO-ID 6954 9611\" /></div>" +
            "<p align=\"center\">Figure 10- BiNGO output for active module 2 and nodes with GO-ID 6954, 9611</p><p>Next, genes annotated as “inflammatory response” and genes annotated as “response to wounding” were selected as new networks.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Genes_annotated_as_inflammatory_response.png\" alt=\"Genes annotated as inflammatory response\" /></div>" +
            "<p align=\"center\">Figure 11 - Genes annotated as 'inflammatory response' (GO-ID 6954)</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Genes_annotated_as_esponse_to_wounding.png\" alt=\"Genes annotated as inflammatory response\" /></div>" +
            "<p align=\"center\">Figure 12 - Genes annotated as 'response to wounding' (GO-ID 9611)</p><p>Finally, the intersection of the annotated genes and the active modules was analysed.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Genes_annotated_as_inflammatory_response_2.png\" alt=\"Genes annotated as inflammatory response\" /></div>" +
            "<p align=\"center\">Figure 13 - Genes annotated as 'inflammatory response' (GO-ID 6954) in active module 1</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Genes_annotated_as_esponse_to_wounding_2.png\" alt=\"Genes annotated as inflammatory response\" /></div>" +
            "<p align=\"center\">Figure 14- Genes annotated as 'response to wounding' (GO-ID 9611) in active module 1</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Genes_annotated_as_inflammatory_response_3.png\" alt=\"Genes annotated as inflammatory response\" /></div>" +
            "<p align=\"center\">Figure 15 - Genes annotated as 'inflammatory response' (GO-ID 6954) in active module 2</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/23022012_Genes_annotated_as_esponse_to_wounding_3.png\" alt=\"Genes annotated as inflammatory response\" /></div>" +
            "<p align=\"center\">Figure 16 - Genes annotated as 'response to wounding' (GO-ID 9611) in active module 2</p><p><strong>6. Discussion</strong></p><p>Scientists have studied a mouse model of tolerance to trypanosomiasis. C57BL/6 mice survive for a relatively long period after infection with T. congolense (110 days), strains such as A/J (16 days) or BALB/c (49 days) are relatively susceptible (Goodhead et al., 2010).</p><p>Hanotter et al (2003) aimed to identify Quantitative Trait Loci (QTL) that control resistance to trypanosomiasis in cattle. They made an experimental cross between trypanotolerant African N'Dama (Bos taurus) and tryptanosusceptible Kenya Boran (Bos indicus)." +
            " They genotyped 177 animals and their parents and grandparents at 477 molecular marker loci covering all autosomes, covering 82% of the genome. The analysis supported a multilocus model for the inheritance of trypanotolerance and ten QTL were identified as contributing to disease tolerance. The location and structure of the QTL regions was determined by using public Single Nucleotide Polymorphisms (SNP) and identifying where the SNPs correlated with survival time in species.</p><p>Kemp et al (1997) genotyped crosses between resistant and susceptible mouse breeds and identified the loci on the chromosomes that had a significant effect on survival time. " +
            "They identified three major QTL that determined the outcome of trypanosome infection in mice and called them Tir1, Tir2 and Tir3.</p><p>Fisher et al (2007) suggested the workflows that combine Microarray and QTL data to search for candidate genes responsible for phenotypic variation. The workflows were applied to the case of resistance to trypanosomiasis in the mouse. An initial list of 344 genes identified in the Tir1 QTL region has been narrowed down to 32 candidate genes. Further, MapK signalling pathway was identified as containing a high proportion of genes that show differential expression. Daxx showed the strongest signal of differential expression and was chosen as the primary candidate.</p>" +
            "<p>Goodhead et al (2010) applied a series of analyses to existing datasets and combined them with novel sequencing and other genetic data to create short lists of genes that share polymorphisms across susceptible mouse breeds. They reduced the initial long list of genes within the QTL regions to a short list of candidate genes with defined genetic differences that correlate with phenotype. Pram1 regulates oxidative stress in neutrophils and Rgl2 is involved in Ras signalling which can regulate inflammation. Pram1 has the best understood functionality and Rgl2 is also a plausible candidate. " +
            "Probably damaging polymorphisms were identified in Srp72 and Thsd7b but little is known of their functions making interpretation hard. Ptprc and Soat1 had probably damaging polymorphisms. Cd244 is differentially expressed and has a haplotype that correlates with phenotype in the four strains tested.</p><p>Goodhead et al (2010) identified Pram1 as the most plausible candidate gene in Tir1. They also identified Cd244 as a strong candidate gene in the Tir3 QTL. Pram1 has several GO annotations, which are “lipid binding”, “regulation of neutrophil degranulation” and “integrin-mediated signalling pathway”. Cd244 is annotated as “natural killer cell receptor 2B4”.</p>" +
            "<p>Pram1 is an intracellular adaptor that is critical for select integrin functions in neutrophils, which are critical for host defence against pathogens (Clemens et al, 2004). From the comparison of the log fold changes for Pram1 in three strains it can be noticed that the value for C57BL/6 is almost three times greater than for A/J and 48 times greater than for BALB/c. However, the absolute value of log fold for Pram1 is not outstanding compared to other genes. This suggests that it is not the absolute value of the log fold that is important, but the difference in the log folds for the same gene across three mouse strains. " +
            "Pram1 was not picked up as part of the active module by the jActiveModules plugin. Consequently, Pram1 could not appear in the output of the BiNGO plugin, suggesting that the technique used may not be optimal for identifying the genes responsible for disease resistance.</p><p>Cd244 is expressed on all Natural Killer cells in mice. It mainly acts as an inhibitory receptor and this function plays a role in maintaining tolerance of Natural Killer cells to self cells (Vaidyaa & Mathew, 2006). Cd244 was identified by the jActiveModules plugin as part of active module 2. " +
            "It should be noted that for this gene the log fold values is lower in the tolerant C57BL/6 strain compared to two other strains. However, the GO annotation for Cd244 did not appear in the output of the BiNGO plugin. The likely explanation is that it was not picked up by the plugin due to low significance values.</p><p><table border=\"1\"><tr><td>Gene</td><td>a07exp</td><td>a07sig</td><td>b07exp</td><td>b07sig</td><td>c07exp</td><td>c07sig</td></tr><tr><td>Pram1</td><td>0.129875</td><td>0.644749889</td><td>0.00729335</td><td>0.978568283</td><td>0.3465516</td><td>0.232430853</td></tr><tr><td>Cd244</td><td>2.020997</td><td>9.93E-7</td><td>1.2643455</td>" +
            "<td>1.81269E-4</td><td>0.6374838</td><td>0.382130858</td></tr></table></p><p align=\"center\">Figure 17 - Significance and expression values for Pram1 and Cd244</p><p>Fisher et al (2007) identified an amino acid deletion in the Daxx gene in susceptible mouse strains and proposed Daxx as a candidate gene in the Tir1 Q TL region. Daxx is annotated as “Death domain-associated protein 6”. Daxx accumulates in both the nucleus and the cytoplasm and has been reported to interact with various proteins involved in cell death regulation. Its precise role in cell death is only partially understood despite a number of studies on the subject (Salomoni & Khelifi, 2006). " +
            "Daxx was also not identified by jActiveModules as part of the active module in the mouse liver network.</p><p><strong>7. Conclusion</strong></p><p>This document describes an attempt to build a model for the mouse response to the infection by Trypanosoma congolense. A large amount of data from microarray experiments is loaded as an interaction network into Cytoscape and then analysed using the jActiveModules and BiNGO plugins. The use of the protocol described in this document allows suggesting several candidate genes but the results are not supported by literature and previous research.</p><p>The BiNGO plugin allows to determine which Gene Ontology terms are overrepresented in the set of genes (Maere, Heymans and Kuiper, 2005)." +
            " It provides the output both as a data table and a visual graph. The visual graph, however, is subject to interpretation and it is hard to determine which nodes in the graph are of the most interest. Maere, Heymans and Kuiper (2005) note that interpretation can be difficult if a whole branch of the GO hierarchy is highlighted as being significantly overrepresented, which is very likely due to the interdependency of functional categories. It should be added that in more complex networks, even when the least significant nodes are not considered, multiple branches may be highlighted as being overrepresented, further complicating the visual analysis.</p>" +
            "<p>Additionally, identifying the nodes of interest only gives a reference to a GO category, which may include a large number of genes. If the goal is to reduce the amount of candidate genes to a number under ten, identifying the overrepresented category would only be one of the first steps.</p><p>While BiNGO is a tool that is flexible and easy to use, its application to the identification of the genes that play a key role in the resistance to a disease is only part of a high-level analysis. Other techniques and workflows will be needed that can use the BiNGO output and use it to further refine the list of candidate genes.</p>" +
            "<p><strong>8. References</strong></p><p>A-L Barabasi, Z. Oltvai, Network biology: Understanding the cell's functional organization, Nature Reviews Genetics, 5:101 (2004)</p><p>R. Clemens, S. Newbrough, E. Chung, S. Gheith, A. Singer et al, PRAM-1 Is Required for Optimal Integrin-Dependent Neutrophil Function, Molecular and cellular biology, 24:10923 (2004)</p><p>M. Cline, M. Smoot, E. Cerami, A. Kuchinsky, N. Landys et al., Integration of biological networks and gene expression data using Cytoscape, Nature protocols 2:2366 (2007)</p>" +
            "<p>P. Fisher, C. Hedeler, K. Wolstencroft, H. Hulme, H. Noyes et al, A systematic strategy for large-scale analysis of genotype–phenotype correlations: identification of candidate genes involved in African trypanosomiasis, Nucleic Acids Research, 35:5625 (2007)</p><p><a href=\"http://www.geneontology.org/\">Gene Ontology website</a>, accessed on 07/01/2012</p><p>I.Goodhead, A. Archibald, P. Amwayi, A. Brass, J. Gibson et al, A Comprehensive Genetic Analysis of Candidate Genes Regulating Response to Trypanosoma congolense Infection in Mice, PLoS Neglected Tropical Diseases 4(11): e880 (2010)</p>" +
            "<p>O. Hanotte, Y. Ronin, M. Agaba, P. Nilsson, A. Gelhaus et al, Mapping of quantitative trait loci controlling trypanotolerance in a cross of tolerant West African N'Dama and susceptible East African Boran cattle, Proceedings of the National Academy of Sciences of the United States of America, 100:7443 (2003)</p><p>S. Kemp, F. Iraqi, A. Darvasi, M. Soller and A. Teale, Localization of genes controlling resistance to trypanosomiasis in mice, Nature genetics, 16:194 (1997)</p><p>S. Maere, K. Heymans and M. Kuiper, BiNGO: a Cytoscape plugin to assess overrepresentation of Gene Ontology categories in Biological Networks, Bioinformatics Applications, 21:3448 (2005)</p>" +
            "<p>H. Noyes, M. Alimohammadian, M. Agaba, A. Brass, H. Fuchs et al., Mechanisms Controlling Anaemia in Trypanosoma congolense Infected Mice, PLoS ONE 4(4): e5170 (2009).</p><p>P. Salomoni, A. Khelifi, Daxx: death or survival protein?, Trends in cell biology, 16:97 (2006)</p><p>S. Vaidyaa, P. Mathew, Of mice and men: Different functions of the murine and human 2B4 (CD244) receptor on NK cells, Immunology letters 2:180 (2006)</p><p><strong>Feedback from the Tutor</strong></p><p>The aims are rather too broad; you could focus more specifically on the strain differences. " +
            "The overall strategy is clear and sensible, but each figure needs a full legend giving the colour scheme used. You have provided a full discussion, but it is organised as 'literature and then my results'. In a report of this type you need to discuss your own results, and then consider whether there is supporting evidence from the literature. List the references with surname first.</p>";
        public const string content_23022012_k = "bioinformatics biology bingo cytoscape plugin jactivemodules Trypanosoma Congolense";
        public const string content_23022012_d = "Building a model for the mouse response to Trypanosoma Congolense using jActiveModules and BiNGO";

        //"Validating Active Modules with BiNGO"
        public const string content_09012012_b = "<p><strong>Introduction</strong></p><p>Gene ontology project provides a controlled vocabulary of terms for describing gene product characteristics and gene product annotation data. The aim of the project is to reduce time spent searching for information related to bioinformatics. The same protein, for example, may be described as participating in ‘translation’ in one database, but ‘protein synthesis’ in another. Gene ontology aims to provide global, consistent descriptions by developing structured vocabularies, or ontologies, that match gene products to associated biological processes.</p>";
        public const string content_09012012_r =
            "<p>BINGO is a Cytoscape plugin that assesses overrepresentation of Gene Ontology categories in biological networks. It can be used on the list of genes pasted in text or on sub-networks of biological networks visualised in Cytoscape. BiNGO uses p-value as the indicator of the prominence of a certain functional category and colour the nodes accordingly. Additionally, when a whole branch of the GO hierarchy is highlighted as overrepresented, the nodes that are farther down the hierarchy are the most relevant ones.</p><p>For the purpose of this exercise, first jActiveModules plugin was used to find active modules (sub-networks) in the network provided." +
            " Next, BiNGO was used to assess the overrepresentation of GO categories in the network. Several relevant nodes were selected from the BiNGO output using the guidelines described above. The GO-IDs of the selected nodes were selected as sub-networks of the network, and the intersection of these sub-networks with the active modules was analysed.</p><p><strong>Methods</strong></p><p>First, jActiveModules plugin was used as in the previous post, and five active modules were identified in the network. The first module, which contained 95 nodes, was used for the exersice.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_Active_Modules.png\" alt=\"Active Modules\" /></div>" +
            "<br><i>Figure 1 – active modules in the network.</i><br><p>BiNGO plugin was started and the settings were specified as advised in the practical exercise directions.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_BiNGO_Plugin_Settings.png\" alt=\"BiNGO Plugin Settings\" /></div>" +
            "<br><i>Figure 2 – BiNGO plugin settings.</i><br><p>The graphical output from BiNGO was a graph where nodes were coloured according to the p-value. The yellow and orange nodes represent gene ontology categories that are overrepresented at the significance level. Uncoloured nodes are not overrepresented themselves, but they are parents of overrepresented nodes further down. Some nodes could be immediately identified as most relevant – there were most intensely coloured and were located away from the centre of the network. Graphical output and some of the relevant nodes were presented in Figure 3.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_Graphical_output_from_BiNGO.png\" alt=\"Graphical output from BiNGO\" /></div>" +
            "<br><i>Figure 3 – graphical output from BiNGO and relevant nodes.</i><br><p>The data output from the BiNGO plugin is the list of significantly overrepresented categories, p-values, frequencies and the list of genes that are included into each category. The output file, module1BP.bgo, is attached.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_BiNGO_data_output.png\" alt=\"BiNGO data output\" /></div>" +
            "<br><i>Figure 4 – BiNGO data output.</i><br><p><strong>GO-ID 48731</strong></p><p>GO-ID 48731 is annotated as “system development”. This is described in GO database as “the biological process whose specific outcome is the progression of an organismal system over time, from its formation to the mature structure.”  The node is relevant as it is intensely coloured and lies away from the centre of the graph. " +
            "Selecting the node in BiNGO data output and clicking “Select Nodes” highlighted all nodes in the original network (not only ones in the active module) which are annotated with “system development” category. The result was a network of 865 nodes. In the Figure 5, ratlung-child is a network that was created from the active module, and ratlung-child.1 is a network that contains the genes annotated as “system development”.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_GOID_48731_in_BiNGO_output.png\" alt=\"GO-ID 48731 in BiNGO output\" /></div>" +
            "<i>Figure 5 – GO-ID 48731 in BiNGO output</i><br>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_System_Development_Nodes.png\" alt=\"System Development Nodes\" /></div>" +
            "<br><i>Figure 6 – ‘system development” nodes in the network.</i><br><p>Next, the “Advanced Network Merge” plugin was used to find the intersection between those two networks.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_Intersection_Between_Active_Module_and_Development.png\" alt=\"Intersection Between Active Module and Development\" /></div>" +
            "<br><i>Figure 7 – intersection between active module and nodes annotated as “system development”</i><br><p><strong>GO-ID 6357</strong></p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_GOID_6357_in_BiNGO_output.png\" alt=\"GO-ID 6357 in BiNGO output\" /></div>" +
            "<br><i>Figure 8 – GO-ID 6357 in BiNGO graphical output</i><br><p>GO-ID 6357 is annotated as “regulation of transcription from RNA polymerase II promoter”. This is described as any process that modulates the frequency, rate of extent of transcription from RNA polymerase II promoter. Selecting the node in BiNGO data output and clicking “Select Nodes” resulted in a network of 292 nodes. The network was then analysed for intersecting with active module 1.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/09012012_Intersection_Between_Active_Module_and_Promoter.png\" alt=\"Intersection Between Active Module and Promoter\" /></div>" +
            "<br><i>Figure 9 – Intersection between active module and nodes annotated as “regulation of transcription from RNA polymerase II promoter”</i><br><p><strong>References:</strong></p><p>S. Maere, K. Heymans and M. Kuiper, BiNGO: a Cytoscape plugin to assess overrepresentation of Gene Ontology categories in Biological Networks, Bioinformatics Applications, 21:3448 (2005)</p>" +
            "<p><a href=\"http://www.geneontology.org\">Gene Ontology Project Website</a></p><p><a href=\"http://www.psb.ugent.be/cbd/papers/BiNGO/Tutorial.html\">BINGO Tutorial</a></p>";
        public const string content_09012012_k = "bioinformatics biology bingo cytoscape plugin gene ontology";
        public const string content_09012012_d = "BINGO is a Cytoscape plugin that assesses overrepresentation of Gene Ontology categories in biological networks. In this essay I consider validating active modules with BiNGO";


        //"Adding Expression Data to the Network"
        public const string content_25022012_b = "<p><strong>Introduction</strong></p><p>The network that I have been using is a generalised view of the interactions that may take place. By adding gene expression data to the network, I will be able to determine which interactions are 'active' under the known experimental conditions. The data provided for analysis was from an experiment to examine the changes in gene expression in the lungs of rats exposed to mustard gas (GSE1888).</p><p>The goal was to find, identify and compare the active modules and how they overlap with the network of proteins affected by mustard gas.</p>";
        public const string content_25022012_r =
            "<p><strong>1. Functional Modules</strong></p><p>When the protein interactions are represented as graphs, they can be used to investigate the functions of proteins through their interactions with neighbouring proteins. Clusters of highly interconnected proteins could not have occurred by chance and are likely to contain proteins with a common biological function (Dunn et al, 2005). Such clusters are called functional modules and their identification is a complex task.</p><p>Bader and Hogue (2003) suggested the three-stage algorithm for finding molecular complexes. The algorithm assigns weights to nodes based on “cliquishness” of a node, which is proportional to the number of nodes in the neighbourhood and inversely proportional to the vertex size of the neighbourhood.</p><p>Dunn et al. (2005) note that in certain cases, such as a prey node attached to the bait by a single edge, a poorly connected node provides useful information. " +
            "Methods that use edge-betweenness, unlike many other clustering methods, will not remove such nodes and are useful when the information associated with these low degree nodes is required.</p><p><strong>2. Finding Active Modules</strong></p><p>The file provided for the exercise contained significance values of the difference in gene expression in rats that were exposed to 6mg/kg mustard gas for 1, 3 and 6 hours. The jActiveModules plugin was used to find active modules. The plugin identified five functional modules ranging from 69 to 95 nodes in size.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Active_Modules.png\" alt=\"Active Modules\" /></div>" +
            "<p><strong>3. Examining Active Modules</strong></p><i>Network from module 1.</i><p>1 hour: all significance values are equal to 0.999783355<br>3 hours: significance values in range of 4.5*10-5 to 0.489861449</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Node_Color_Editor.png\" alt=\"Node Color Editor\" /></div>" +
            "<p>Graphical view, with nodes having higher significance values coloured with darker red.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Child_Network.png\" alt=\"Child Network\" /></div>" +
            "<p>In this network, only five proteins have significance values over 0.01.</p><p>6 hours: significance values in range of 6.13*10<sup>-8</sup> to 0.916047284</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Child_Network_2.png\" alt=\"Child Network\" /></div>" +
            "<p>This time, over 30 proteins have significance values over 0.01.</p><i>Network from module 2.</i><p>1 hour: all significance values are equal to 0.999783355<br><br />3 hours: significance values in range of 4.5*10<sup>-5</sup> to 0.489861449</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Child_Network_3.png\" alt=\"Child Network\" /></div>" +
            "<p>6 hours: significance values in range of 6.13*10<sup>-8</sup> to 0.916047284</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Child_Network_4.png\" alt=\"Child Network\" /></div>" +
            "<p><strong>4. Comparing the Modules Identified</strong></p><p>After networks were created from first three of the five active modules identified, the Cytoscape plugin Advanced Network Merge was used to merge these three modules.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Advanced_Network_Merge.png\" alt=\"Advanced Network Merge\" /></div>" +
            "<p>The merged network which is coloured according to the differential expression at 6 hours was represented on the image below:</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/25022012_Merged_Network.png\" alt=\"Merged Network\" /></div>" +
            "<p>It is not immediately obvious from the picture how strongly the three networks which were merged into one overlap. One observation is that the merged network has 118 nodes, while the three child networks would have 95 + 44 + 72 = 211 nodes if there was no overlap. This is an indication that a significant number of nodes are present in two or three child networks.</p><p>Another approach may be to compare the proteins with high p-values. To fill the table below, the nodes in each of the child active modules were sorted by p-value at 6 hours. Then ten proteins with highest p-values were inserted into the table. One protein (Icam1) was present in all three “top tens”. Module 1 and 2 share one other protein (Krt19), and modules 1 and 3 share one other protein (Lpl), while modules 2 and 3 share five other proteins (Cd36, Hamp, Sacm11, Tim3, Dusp1). " +
            "From this basic analysis it can be roughly estimated that all three modules are overlapped to some extent, and modules 2 and 3 are more significantly overlapped compared to module 1 and 2 or 1 and 3. Further more detailed analysis is required to make more exact conclusions.<table text-align=\"center\"><tr><th>Active Module 1</th><th>Active Module 2</th><th>Active Module 3</th></tr><tr><td align=\"center\">Lpl</td><td></td><td align=\"center\">Lpl</td></tr><tr><td align=\"center\">Sele</td><td></td><td></td></tr><tr><td align=\"center\">Icam1</td><td align=\"center\">Icam1</td><td align=\"center\">Icam1</td></tr><tr><td align=\"center\">Il18</td><td></td><td></td></tr><tr><td align=\"center\">Krt19</td><td align=\"center\">Krt19</td><td></td></tr><tr><td align=\"center\">Nr1h3</td><td></td><td></td></tr><tr><td align=\"center\">Pla2g1b</td><td></td><td></td></tr><tr>" +
            "<td align=\"center\">Col5a2</td><td></td><td></td></tr><tr><td align=\"center\">Nt5e</td><td></td><td></td></tr><tr><td align=\"center\">Pawr</td><td></td><td></td></tr><tr><td></td><td></td><td align=\"center\">Axin1</td></tr><tr><td></td><td align=\"center\">Cd36</td><td align=\"center\">Cd36</td></tr><tr><td></td><td align=\"center\">Hamp</td><td align=\"center\">Hamp</td></tr><tr><td></td><td align=\"center\">Sacm1l</td><td align=\"center\">Sacm1l</td></tr><tr><td></td><td align=\"center\">Timp3</td><td align=\"center\">Timp3</td></tr><tr><td></td><td></td><td align=\"center\">Mark3</td></tr><tr><td></td><td align=\"center\">Dusp1</td><td align=\"center\">Dusp1</td></tr><br /><tr><td></td><td align=\"center\">Phlda1</td><td></td></tr><tr><td></td><td align=\"center\">Pcm1</td><td></td></tr><tr><td></td><td align=\"center\">Raf1</td><td></td></tr><tr><td></td><td></td><td align=\"center\">Gsk3b</td></tr></table><p><strong>References:</strong></p>" +
            "<p>R. Dunn, F. Dudbridge, C. Sanderson, The Use of Edge-Betweenness Clustering to Investigate Biological Function in Protein Interaction Networks, BMC Bioinformatics, 6:39 (2005)</p><p>G. Bader, C. Hogue, An automated method for finding molecular complexes in large protein interaction networks, BMC Bioinformatics, 4:2 (2003)</p><p><strong>Feedback</strong></p><p>You have identified and shaded active modules. However, it is more interesting at this stage to shade by fold change, rather than by significance value. By using the fold change values (1hexp, 3hexp, 6hexp) you can see which parts of your network are up/down-regulated over the course of the experiment. In the practical instructions I suggested that you use the intersection option when merging your networks. This does show you the extent of the overlap.</p><p><strong>My Comment</strong></p><p>It was quite stupid of me to use 'union' instead of 'intersect' when merging networks and then record that there are no obvious observations.</p>";
        public const string content_25022012_k = "bioinformatics biology modeling network expression data";
        public const string content_25022012_d = "Adding Expression Data to the Network";

        //"Network Topology"
        public const string content_25122011_b = "<p><strong>Degree distribution and power law.</strong></p><p>For a long time the graph theory modelled complex networks either as being regular objects, or as being completely random. An important finding was that the number of nodes with a given degree does not follow the Poisson distribution, but follows a power law (Barabasi & Oltvai, 2004)</p><p>That means that the probability to find a hub with a number of neighbours a magnitude higher is a magnitude lower, but still not negligible (Bode et al, 2007).</p>";
        public const string content_25122011_r =
            "<p>In simple terms, a node with a degree of 10 will be found 10 times less often, than the node with a degree of 1, and the node with a degree of 100 - 100 times less often.</p><p>Such networks are called scale-free, which means that it is not possible to find a typical node in the network - one that could be used to characterize the rest of the nodes. The evidence that cellular networks are scale-free came from the analysis of metabolism networks of various organisms. As a typical feature of the scale-free network, most of the proteins only participate in a few interactions, but there is a small number of proteins which participate in dozens interactions. Alternatively it can be described as a small number of hubs (highly connected nodes) which hold the whole network together. (Barabasi & Oltvai, 2004)</p>" +
            "<p>From the evolutionary point of view, there are two factors that explain scale-free nature of cellular networks. One is the fact that most network are a result of a very slow growth over an extended time period, and the other is that new nodes are more likely to connect to nodes which already have many links. (Barabasi & Oltvai, 2004)</p><p>Not everyone agrees to the fact that the node degree distribution follows a power law. Tanaka et al (2005) studied the two publicly available networks, the FYI (filtered yeast interactome) and human protein interaction (HPI) maps and investigated whether their node degree sequences follow a power law. Their conclusion was that usage of frequency-degree plots leads to errors which can easily be avoided by using rank-degree plots and the node degree sequences of these networks are clearly not power laws, but much closer to exponential.</p>" +
            "<p><strong>Betweenness Centrality</strong></p><p>Betweenness is a quantitative measure for describing the centrality of nodes in a network, provided as the frequency with which a node is located on the shortest path between all other nodes. Nodes with high betweenness control the flow of information across a network. There is a positive correlation between the centrality of the proteins and their essentiality in many species, and there is also a positive correlation between centrality and node degree. (Yamada & Bork, 2009)</p><p>Betweenness centrality lies at the core of both transport and structural vulnerability properties of complex networks; however, it is computationally costly, and its measurement for networks with millions of nodes is nearly impossible. (Ercsey-Ravasz & Toroczkai, 2010).</p>" +
            "<p>One of the practical applications of betweenness centrality is the drug design. Hormozdiari et al (2010) suggest that if the essential pathways in a pathogenic organism are known, it should be possible to compute the minimum number of proteins that need to be targeted as many essential pathways as possible. The proteins with the highest betweenness will be the most obvious choices but, of course, the algorithm is not that simple and includes a schema whether the proteins are also weighted based on the presence of an ortholog of a protein in the host. We wouldn't want a drug to target vital proteins in our own body.</p><p><strong>Calculating and using network statistic.</strong></p><p><i>Node degree distribution</i></p><p>It is evident that there is a large number of nodes with a low node degree, but there is only a handful of nodes with a degree over 100. The degree distribution does not appear to be random and it is known from literature that it usually follows a power law.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Network_Analysis.png\" alt=\"Network Analysis\" /></div>" +
            "<br />Figure 1 – node degree distribution in a large network.<p><i>Fitting a power law.</i></p><p>The power law was fitted as follows: y=3391.6 * x<sup>-1.698</sup>. The power law explains 92.5% of the distribution, which is a very good fit. This is also evident from the fact that the residues appear to be distributed randomly to the both sides of the fitted line and close to the line.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Network_Analyser.png\" alt=\"Network Analyser\" /></div>" +
            "<br />Figure 2 – power law fitted function" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Network_Analysis_Fit_Line.png\" alt=\"Network Analysis Fit Line\" /></div>" +
            "Figure 3 – power law fitted graph.<p><i>Betweenness centrality</i></p>" +
            "<p>The value of betweenness centrality is normalized and therefore lies between 0 and 1.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Betweenness_Centrality.png\" alt=\"Betweenness Centrality\" /></div>" +
            "Figure 4 – betweenness centrality in a large network.<p><i>Removing the largest component.</i></p><p>The largest connected component in the network being studied has 2623 nodes, which is the majority of the nodes of the whole network and the largest of the other components is only 12 nodes.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Connected_Components.png\" alt=\"Connected Components\" /></div>" +
            "Figure 5 – largest connected components of a large network.<p>Below is the second largest of components, with the node marked in yellow having a high betweenness centrality of 0.7:</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Connected_Component.png\" alt=\"second largest connected component of large network\" /></div>" +
            "Figure 6 – second largest connected component of large network<p>This node connects two “clusters” of 5 and 4 nodes, and two other nodes. Since the definition of betweenness is “number of shortest paths from all nodes to all others that pass through that node”, it has a relatively high betweenness.</p>" +
            "<p><i>Several example nodes from the largest connected components:</i></p><p>A node with high betweenness centrality (0.082), high degree (150) : Cam1. The node has a high degree, so it is connected to many other nodes in the network. Therefore a significant number of shortest paths passes through the node. It can also be seen that a significant number of nodes other than Cam1 are directly connected to each other, reducing the betweenness of Cam1.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Connected_Component_2.png\" alt=\"Cam1 and neighbouring nodes\" /></div>" +
            "Figure 7 – Cam1 and neighbouring nodes.<p>A node with relatively high betweenness centrality (0.01), low degree (10) : Csnk2b. This one is not obvious to me, I would expect the betweenness of this node to be higher since it appears to be central to its five neighbours. Probably as part of the whole connected component it belongs to the peripheral area of the network.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Connected_Component_3.png\" alt=\"Csnk2b and neighbouring nodes\" /></div>" +
            "Figure 8 – Csnk2b and neighbouring nodes.<p>A node with low betweenness centrality (0), relatively high degree (28) : Ndufb8. Nodes other than Ndufb8 are highly connected, so only a small number of shortest paths between nodes pass through Ndufb8.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Connected_Component_4.png\" alt=\"Ndufb8 and neighbouring nodes\" /></div>" +
            "Figure 9 – Ndufb8 and neighbouring nodes.<p>A node with low betweenness centrality (0), low degree (4) : Fbxo11. There is only one node here other than Fbxo11, so there are no routes between nodes other than Fbxo11 at all.</p>" +
            "<div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2011/25122011_Connected_Component_5.png\" alt=\"Fbxo11 and neighbouring nodes\" /></div>" +
            "Figure 10 – Fbxo11 and neighbouring nodes.<p><strong>References:</strong></p><p>A-L Barabasi, Z. Oltvai, Network biology: Understanding the cell's functional organization, Nature Reviews Genetics, 5:101 (2004)</p><p>T. Yamada, P. Bork, Evolution of biomolecular networks - lessons from metabolic and protein interactions, Nature Reviews Molecular Cell Biology, 10:791 (2009)</p><p>R. Tanakaa, T. Yi, J. Doyle, Some protein interaction data do not exhibit power law statistics. FEBS Letters, 579:514 (2005)</p>" +
            "<p>C. Bode, I. Kovacs, M. Szalay, R. Palotai, T. Korcsmaros et al., Network analysis of protein dynamics, FEBS Letters, 581:2776 (2007)</p><p>M. Ercsey-Ravasz, Z. Toroczkai, Centrality scaling in large networks, Physical review letters, 105:38701(2010)</p><p>F. Hormozdiari, R. Salari, V. Bafna, S. Sahinalp, Protein-protein interaction network evaluation for identifying potential drug targets, Journal of Computational Biology, 17:669 (2010)</p>";
        public const string content_25122011_k = "bioinformatics biology modeling network topology";
        public const string content_25122011_d = "Network topology, degree distribution and power law in biological networks";

        //"COPASI and CellDesigner: Comparison"
        public const string content_27112012_b = "<p><a href=\"http://www.copasi.org/tiki-view_articles.php\">COPASI</a> and <a href=\"http://www.celldesigner.org/\">CellDesigner</a> are software packages for modelling and simulation of biochemical networks.</p>";
        public const string content_27112012_r = "<p><strong>1. Common features</strong></p><p>Models in both packages are based on compartments, species and reactions. Both packages have an area where the model tree is displayed, the area for entering and editing model parameters</p><p><strong>2. Differences</strong></p><p><strong>2.1 CellDesigner</strong></p><p>Networks are drawn based on the process diagram and are stored using SBML. CellDesigner supports a rich set of graphical elements for various compartments, species and reactions. There are predefines shapes for certain species, such as ‘truncated protein’ or ‘simple molecule’, or reactions, such as ‘transport’ or ‘dissociation’. Elements are added to the module by selecting them from a toolbar. Visual representation of the model is the strong advantage of CellDesigner. Figure 1 represents a model of MAPK-42 opened with CellDesigner. CellDesigner allows entering kinetic reactions by hand, but does not have predefined rate laws so they also have to be entered by hand for each reaction.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/27112012_CellDesigner_with_MAPK-42_model.png\" alt=\"CellDesigner with MAPK-42 model\" /></div><p align=\"center\">Figure 1 - CellDesigner with MAPK-42 model</p><p><strong>2.2 COPASI</strong></p><p>COPASI is less rich visually, but has advanced functionality for model simulation and analysis. The species are added to the model automatically by typing the attributes into the line in the list. Reactions can also be added directly by typing the chemical equation into the cell in the table. Unlike CellDesigner, COPASI has a number of predefined kinetic laws, can switch between stochastic and deterministic simulation methods and supports a number of methodologies for model analysis – computation of steady states, stoichiometric matrix, parameter estimation and optimisation. An important feature is the mathematical view where the model is described as a set of differential equations. Figure 2 represents the same model of MAPK-42 opened with COPASI, where differential equations are shown.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/27112012_COPASI_with_MAPK-42_model.png\" alt=\"COPASI with MAPK-42 model\" /></div><p align=\"center\">Figure 2 - COPASI with MAPK-42 model</p><p><strong>3. SBML support</strong></p><p>Both packages can read and write SBML, which is a file format for exchanging systems biology models. CellDesigner stores visual layout information in SBML annotations, but also has an option of exporting into ‘pure’ SBML in case conversion is required to a different software package which does not support annotations. CellDesigner can read and write SBML, and store rich enhanced functions as SBML annotations. COPASI converts its native model structure to SBML on exporting. Notes and annotations are preserved while importing and re-exporting as long as the objects that contains them is not deleted from the model.</p><p><strong>4. Conclusion</strong></p><p>While the strongest advantage of CellDesigner is the support for model building and editing via rich graphical representation, COPASI appears to be more suitable for simulation and analysis.</p><br/>by <a rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_27112012_k = "Digital biology COPASI CellDesigner biochemical network simulation modelling";
        public const string content_27112012_d = "COPASI and CellDesigner are software packages for modelling and simulation of biochemical networks. This brief essay compares their functionality";

        //"Calculation of Phase Space Models with COPASI"
        public const string content_29102012_b = "<p><strong>COPASI</strong> is an open source modelling and simulation package for biochemical networks, capable of simulation based on ODEs and stochastic kinetics, and models can include discrete events.</p>";
        public const string content_29102012_r = "<p>A phase space diagram is a type of plots used to describe models that have complex dynamics. The axes represent the variables of the system, and each point in this space represents a state of the system. A trajectory in the phase-space is a line of points that describe the evolution of the state of the system, however time is not explicitly represented in such plots (even though it is implicit).</p><p>If the model has two variables, plotting them against each other is an obvious task. What if the model has three variables, like a model of calcium oscillations? At this time, COPASI can only display 2D plots. One solution is to display 2D projections of the phase space. For a model with 3 variables there are 3 possible projections: a vs b, a vs c and b vs c.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/29102012_Calcium_Oscillation_Model.png\" alt=\"Calcium Oscillation Model\" /></div><p>To create a phase space model, first download a model. In this case it is described in <strong>SBML</strong>. COPASI has an option for importing SBML: <strong>File -> Import SBML</strong>. COPASI may generate some warnings. In the left panel one can see the 3 species and 8 reactions included in the model.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/29102012_Create_Species.png\" alt=\"Create Species\" /></div><p>To create a phase-space diagram locate <strong>Output Specifications -> Plots</strong> down in the left panel. In the <strong>Plots</strong> panel on the right click new, and a plot with a default name is created.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/29102012_Create_Plot.png\" alt=\"Create Plot\" /></div><p>Double-click the plot in the panel. Now you can give it a meaningful name, and then click <strong>New curve</strong>. This is where you select the axis of the plot. In this diagram, transient concentrations of species will be plotted. Select a for X axis and b for Y axis and click OK.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/29102012_Measure_Transient_Concentrations.png\" alt=\"Measure Transient Concentrations\" /></div><p>Now a 2D curve appears in the right panel. Parameters can be edited to make them more intuitively understandable. Then, click <strong>Commit</strong> and select <strong>Tasks -> Time Course</strong> in the left panel. In the <strong>Time Course</strong> panel, click <strong>Run</strong>.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/29102012_Time_Course.png\" alt=\"Time Course\" /></div><p>The result is the phase space diagram of the transient concentrations of species a vs b. Other plots are created in a similar way.</p><div class=\"separator\" style=\"clear: both; text-align: center;\"><img src=\"../../../Content/images/blog/db/2012/29102012_Time_Course_Diagram.png\" alt=\"Time Course Diagram\" /></div><p><strong>References</strong></p><a href=\"http://www.copasi.org/tiki-view_articles.php\">COPASI website</a><br/><a href=\"http://www.comp-sys-bio.org/tiki-download_file.php?fileId=41\">Kummer et al. - Model of calcium oscillations of Kummer et al. </a><br/>by <a rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_29102012_k = "Digital biology COPASI biochemical network simulation modelling phase space";
        public const string content_29102012_d = "COPASI is an open source modelling and simulation package for biochemical networks. This brief essay describes calculation of phase space";

        //Stoichiometry matrix
        public const string content_20122012_b = "<p><strong>1. Definition</strong></p><p>Stoichiometry matrix (SM) is a systematic arrangement of stoichiometric information from the reactions comprising the model. In a system with m species and n reactions the dimensions of the matrix are mxn. Chemical species are represented by rows and reactions – by columns. The elements of the matrix are corresponding stoichiometric coefficients. The selection of the system boundaries defines the complexity of the SM. When the concentration of a specie is considered fixed, the reaction is removed from the matrix.</p>";
        public const string content_20122012_r = "<p>The set of equations represented in the matrix together expresses the dynamics of the metabolite concentrations as</p><p align=\"center\">dS/dt = N*v,</p><p>where N is the matrix, v is the vector of fluxes and S is the vector of metabolite concentrations.</p><p><strong>2. Applications</strong></p><p>SM implies a steady state assuming that at any given time the concentration of the specie is constant. By using SM it is possible to enumerate all possible steady state flux solutions of a given network.</p><p>Personally, I like the fact that the SM is a crossroads of mathematics and biology, equally making sense for a person with a background in biology or information technology or mathematics.</p><p><strong>2.1. Network reconstruction</strong></p><p>The whole table of reactions encoded in the genome may be represented as SM. If the genes that encode for enzymes and reactions that each enzyme carries out are listed, the resulting table can be converted into the SM.</p><p><strong>2.2. Mass conservation analysis</strong></p><p>SM contains all information about the reaction network, therefore all necessary data to analyse mass conservation. Such relations can be retrieved from the SM as linear combinations of other rows. The result of removing all rows that are linear combinations of other rows is the reduced matrix which is used by software packages such as COPASI.</p><p><strong>2.3. Stoichiometric modelling</strong></p><p>In stoichiometric modelling, there are three major approaches are metabolic flux analysis (MFA), flux balance analysis (FBA) and metabolic pathway analysis (MPA). All three work by defining a high-dimension solution space of possible metabolic flux distributions based on the SM specifying system conservation relationships. The difference between the three approaches lies in how metabolic flux distributions are selected from the solution space.</p><p>MFA is a traditional approach which relies on extensive experimental data and computes a metabolic flux vector for a particular condition. Experimental data is used to simplify the SM.</p><p>FBA identifies only one optimal solution while alternative optimal solutions may exist. It very much depends on the validity of the model.</p><p>MPA, unlike the other two methods, can identify all metabolic flux vectors in a network. A finite set of solutions is achieved by additional constraints on the flux space.</p><p><strong>References</strong></p><p>Smolke C, <i>The Metabolic Pathway Engineering Handbook: Fundamentals</i>, CRC Press, 2009</p><p>Trinh T, Wlaschin A, Srienc F, <i>Elementary Mode Analysis: A Useful Metabolic Pathway Analysis Tool for Characterizing Cellular Metabolism</i>, Appl Microbiol Biotechnol, 2009, 81(5), pp 813-826</p><p>Wang X, Chen J, Quinn P, <i>Reprogramming Microbial Metabolic Pathways</i>, Springer, 2012</p>by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_20122012_d = "Stoichiometry matrix";
        public const string content_20122012_k = "Stoichiometry matrix bioinformatics digital biology";

        //Project ROSALIND: Finding a Protein Motif
        public const string content_30042013_b = "<p>The following piece of code is an attempt to solve the \"Finding a Protein Motif\" puzzle from the <a href=\"http://rosalind.info/problems/mprt/\">Project Rosalind</a>.</p><p>The input is a list of <b>UniProt</b> Protein Database access IDs. For each ID, the code reads the protein aminoacid sequence from the url in the form of <a href=\"http://www.uniprot.org/uniprot/B5ZC00.fasta\">http://www.uniprot.org/uniprot/uniprot_id.fasta</a>. Then, for each protein, it searches for the N-glycosylation motif (a motif is a significant amino acid pattern), which is written as <b>N{P}[ST]{P}</b>. In this format, <b>[X]</b> means any aminoacid, and <b>{X}</b> means any amino acid except X.</p><p>The code properly handles overlaps, i.e. in the <b>NMSNSSS</b> string there are two overlapping substrings that satisfy the motif: <b>NMSN</b> and <b>NSSS</b>. The overlaps are not handled properly by the <b>Regex.Matches</b> method (some matches are missed), so some additional string manipulations were required.</p><p>The url <a href=\"http://prosite.expasy.org/scanprosite/\">http://prosite.expasy.org/scanprosite/</a> can be used to verify the output.</p>";
        public const string content_30042013_r = "<pre class=\"brush:csharp\">" + @"List&lt;string&gt; proteins = new List&lt;string&gt;();

string line;
using (StreamReader reader = new StreamReader(""input.txt""))
{
	while ((line = reader.ReadLine()) != null)
	{
		proteins.Add(line);
	}
}

WebClient client = new WebClient();
Dictionary&lt;string, string&gt; proteinsDict = new Dictionary&lt;string, string&gt;();
foreach (string id in proteins)
{
	Stream stream = client.OpenRead(""http://www.uniprot.org/uniprot/"" + id + "".fasta"");

	if (stream != null)
		using (StreamReader reader = new StreamReader(stream))
		{
			string protein = string.Empty;
			while ((line = reader.ReadLine()) != null)
			{
				if (!line.StartsWith(""&gt;""))
				{
					protein += line;
				}
			}

			proteinsDict.Add(id, protein);
		}
}

const string pattern = @""N[^P][ST][^P]"";

using (StreamWriter writer = new StreamWriter(""output.txt""))
{
	foreach (KeyValuePair&lt;string, string&gt; kvp in proteinsDict)
	{
		string val = kvp.Value;
		List&lt;int&gt; matches = new List&lt;int&gt;();
		int removed = 0;
		bool done = false;
		while (done == false)
		{
			Match match = Regex.Match(val, pattern);
			if(match.Success)
			{
				int index = val.IndexOf(match.Value);
				matches.Add(index + removed + 1);
				removed += index + 1;
				val = val.Substring(index + 1, val.Length - (index + 1));
			}
			else
			{
				done = true;
			}
		}

		if(matches.Count &gt; 0)
		{
			string indices = string.Empty;
			writer.WriteLine(kvp.Key);
			indices = matches.Aggregate(indices, (current, index) =&gt; current + index + "" "");
			writer.WriteLine(indices);
		}
	}
}" + "</pre><p><b>References</b></p><a href=\"http://rosalind.info/problems/mprt/\">Finding a Protein Motif</a><br/><a href=\"http://rosalind.info/users/Evgeny_Rokhlin/\">My Profile at Project ROSALIND</a><br/>" +
   "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_30042013_d = "Solving the Finding a Protein Motif problem from Project ROSALIND";
        public const string content_30042013_k = "Project ROSALIND Protein Motif C# bioinformatics";

        //Metabolic Control Analysis and Enzyme Kinetics
        public const string content_14052013_b = "<p><b>1.	Drawbacks of rate-limiting step concept</b></p>";
        public const string content_14052013_r = "<p>At a steady state, the flux through each pathway in a biochemical network is a function of the individual enzyme kinetic properties. The activities of the enzyme affect the concentration of its reactants and products and influence the flux through pathways. Metabolic control analysis (<b>MCA</b>) provides a mathematical framework to study the distribution of metabolic fluxes and concentrations among the pathways that comprise the model. It replaces the principle of the rate-limiting step, which proved to be ineffective in practice. The control of the system as a whole is much more distributed than it was appreciated, making rate-limited step not very useful.</p><p><b>2.	Purpose of MCA</b></p><p>The purpose of the MCA is to identify the steps which have the strongest effect on the levels of metabolites and fluxes. Its basis is the overall steady state flux with respect to the individual enzyme activities.</p><p><b>3.	MCA coefficients</b></p><p>The challenge in analysing a metabolic network is determination of flux control coefficients (<b>FCC</b>). The FCC is a measure of how the flux changes in response to small perturbations in the activity or concentration of the enzyme. The value of the FCC is a measure of how important a particular enzyme is in the determination of the steady state flux. Another set of variables are elasticity coefficients. They quantify the influence of the pool levels on the individual pathway reactions.</p><p><b>4.	MCA theorems</b></p><p>MCA uses two theorems. First is the summation theorem, which states that the sum of all FCC related to a particular pathway equal to 1. A more important theorem is the connectivity theorem; as it provides understanding of the way enzyme kinetics affect the values of FCC. It states that the sum of the products of the FCC of all steps that are affected by <i>X</i> and their elasticity coefficients towards <i>X</i>, is zero</p><p><b>5.	Estimating FCC</b></p><p>There are several ways of estimating FCC, which can be roughly divided into experimental estimation and modelling.</p><p><b>5.1	Experimental estimation</b></p><p><ul><li>Changes can be introduced into enzyme activities and changes in flux measured.</li><li>Elasticity coefficients can be calculated if the kinetics of each step of the pathway are known, then FCC can be calculated from elasticity coefficients</li><li>In-vitro titration of enzyme activities</li></ul></p><p><b>5.2	Estimation through modelling</b></p><p><ul><li>From their definition by small change in reaction rate and calculation of the resulting change in flux or concentration</li><li>From matrix methods that use summation and connectivity theorems. The first approach is based on two matrices, one containing elasticity coefficients and another containing FCC. This approach works but is hard to implement in software. Alternative approach, developed by Reder, requires only knowledge of stoichiometry matrix and elasticity coefficients. This method is best for software calculation of FCC from elasticity coefficients.</li></ul></p>" + "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
        public const string content_14052013_d = "Metabolic Control Analysis and Enzyme Kinetics";
        public const string content_14052013_k = "metabolic control analysis enzyme kinetics flux bioinformatics digital biology";

        //Some string manipulations for future use.
        public const string content_01062013_b = "<p><u>1. Using an array of characters, return all possible permutations of this array (without repetitions).</u></p>";
public const string content_01062013_r = "<pre class=\"brush:csharp\">" + @"public static List&lt;string&gt; StringPermutations(char[] list)
{
	List&lt;string&gt; result = new List&lt;string&gt;();
	int x=list.Length-1;
	go(list,0,x, result);
	return result;
}

private static void go (char[] list, int k, int m, List&lt;string&gt; result)
{
	int i;
	if (k == m)
	{
		result.Add(new string(list));
	}
	else
	for (i = k; i &lt;= m; i++)
	{
		swap (ref list[k],ref list[i]);
		go (list, k+1, m, result);
		swap (ref list[k],ref list[i]);
	}
}

private static void swap(ref char a, ref char b)
{
	if (a == b) return;
	a ^= b;
	b ^= a;
	a ^= b;
}" + "</pre><p>Sample usage</p><pre class=\"brush:csharp\">" + @"List&lt;string&gt; permutations = Helper.StringPermutations(new char[] {'D', 'N', 'A'});" + @"</pre><p>Sample output</p><blockquote>DNA<br>
DAN<br>
NDA<br>
NAD<br>
AND<br>
ADN</blockquote>" + "<p><u>2. Using an array of characters (\"alphabet\"), return all possible words generated from this alphabet of a specified length</u></p><pre class=\"brush:csharp\">" + @"public static IEnumerable&lt;String&gt; GetWordsWithRepetition(Int32 length, char[] alphabet)
{
	if (length &lt;= 0)
		yield break;

	for(int i = 0; i &lt; alphabet.Length; i++) 
	{
		char c = alphabet[i];
		if (length &gt; 1)
		{
			foreach (String restWord in GetWordsWithRepetition(length - 1, alphabet))
				yield return c + restWord;
		}
		else
			yield return """" + c;
	}
}" + "</pre><p><u>3. Further can be used to get full \"dictionary\" with all possible words up to a specified length</u></p><pre class=\"brush:csharp\">" + @"public static string ALPHABET = ""D N A"";

public static List&lt;string&gt; Dictionary(int length)
{
	char[] alphabet = Helper.AlphabetFromString(ALPHABET);

	List&lt;string&gt; final = new List&lt;string&gt;();

	for (int i = 1; i &lt;= length; i++)
	{
		List&lt;string&gt; result = Helper.GetWordsWithRepetition(i, alphabet).ToList();
		final.AddRange(result);
	}
	return final;
}

public static char[] AlphabetFromString(string input)
{
	string[] split = input.Split(' ');
	char[] alphabet = new char[split.Count()];
	for (int i = 0; i &lt; alphabet.Length; i++)
	{
		alphabet[i] = split[i][0];
	}
	return alphabet;
}" + "</pre><p><u>4. Further can be used to sort the words of the dictionary according to the alphabet provided using a comparer</u></p><pre class=\"brush:csharp\">" + @"public static int WordComparer(string one, string two)
{
	char[] alphabet = AlphabetFromString(ALPHABET);

	int len = Math.Min(one.Length, two.Length);
	for (int i = 0; i &lt; len; i++)
	{ 
		int posOne = Array.IndexOf(alphabet, one[i]);
		int posTwo = Array.IndexOf(alphabet, two[i]);
		if (posOne == posTwo)
		{
			continue;
		}
		else if(posTwo &gt; posOne)
		{
			return -1;
		}
		return 1;
	}
	return two.Length &gt; one.Length ? -1 : 1;
}" + "</pre><p>Sample usage</p><pre class=\"brush:csharp\">" + @"List&lt;string&gt; final = Dictionary(3).Sort(WordComparer);" + @"</pre><p>Sample output</p><blockquote>D<br>
DD<br>
DDD<br>
DDN<br>
DDA<br>
DN<br>
DND<br>
DNN<br>
DNA<br>
DA<br>
DAD<br>
DAN<br>
DAA<br>
N<br>
ND<br>
NDD<br>
NDN<br>
NDA<br>
NN<br>
NND<br>
NNN<br>
NNA<br>
NA<br>
NAD<br>
NAN<br>
NAA<br>
A<br>
AD<br>
ADD<br>
ADN<br>
ADA<br>
AN<br>
AND<br>
ANN<br>
ANA<br>
AA<br>
AAD<br>
AAN<br>
AAA</blockquote>" + "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
public const string content_01062013_d = "String functions to construct words and dictionaries";
public const string content_01062013_k = "C# bioinformatics string function set permutation dictionary sorting";

//Project ROSALIND: Finding a shortest superstring
public const string content_10062013_b = "<p>For a collection of strings, a larger string containing every one of the smaller strings as a substring is called a superstring. This may be useful, for example, if we have a large number of pieces of a DNA and want to figure out how the full DNA could look like.</p>";
public const string content_10062013_r = "<p>For example, for the following strings</p><blockquote>ATTAGACCTG<br>CCTGCCGGAA<br>AGACCTGCCG<br>GCCGGAATAC<br></blockquote><p>The shortest superstring will be</p><blockquote>ATTAGACCTGCCGGAATAC</blockquote><p>The following code is a naive approach to solve the problem. The logic is as follows: Sort the list of strings by length. Take the longest one and call it a superstring. Next, iterate through the list to find the string that has the longest intersection with the superstring. Remove that string from the list and attach to the superstring. Continue until the list is empty, the resulting superstring should be the shortest possible.</p><pre class=\"brush:csharp\">" + @"public static string ShortestSuperstring(List&lt;string&gt; input)
{
	input = input.OrderByDescending(x =&gt; x.Length).ToList();

	string superstring = input[0];
	input.RemoveAt(0);
	int counter = input.Count;
	for (int i = 0; i &lt; counter; i++)
	{
		List&lt;IntBoolString&gt; items = new List&lt;IntBoolString&gt;();

		for (int j = 0; j &lt; input.Count; j++)
		{
			items.Add(GetIntersection(superstring, input[j]));
		}

		IntBoolString chosen = items.OrderByDescending(x =&gt; x.intValue).First();

		superstring = CombineIntoSuper(superstring, chosen);
		input.Remove(chosen.stringValue);
	}

	return superstring;
}

private static IntBoolString GetIntersection(string super, string candidate)
{
	IntBoolString result = new IntBoolString();
	result.stringValue = candidate;

	int i = 0;

	while (candidate.Length &gt; i)
	{
		int testlen = candidate.Length - i;
		string leftcan = candidate.Substring(0, testlen);
		string rightcan = candidate.Substring(i, testlen);
		string leftsuper = super.Substring(0, testlen);
		string rightsuper = super.Substring(super.Length - testlen, testlen);

		if (leftcan == rightsuper || rightcan == leftsuper)
		{
			result.boolValue = (leftcan == rightsuper) ? true : false;
			result.intValue = testlen;
			return result;
		}

		i++;
	}

	return result;
}

private static string CombineIntoSuper(string superstring, IntBoolString chosen)
{
	string toAppend = string.Empty;
	int lenToAppend = chosen.stringValue.Length - chosen.intValue;

	toAppend = (chosen.boolValue == true) ?
		chosen.stringValue.Substring(chosen.stringValue.Length - lenToAppend, lenToAppend) :
		chosen.stringValue.Substring(0, lenToAppend);

	superstring = (chosen.boolValue == true) ?
		superstring + toAppend :
		toAppend + superstring;

	return superstring;
}

public struct IntBoolString
{
	public string stringValue;
	public int intValue;
	public bool boolValue;
}" + "</pre>" + "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
public const string content_10062013_d = "An ineffective algorithm to find a shortest superstring for a set of strings";
public const string content_10062013_k = "ROSALIND bioinformatics shortest superstring algorithm programming C#";

public const string content_13072013_b = "<p><b>Stochastic and deterministic modelling.</b></p>";
public const string content_13072013_r = "<p><b>1. Purposes of stochastic modelling</b></p><p>Deterministic modelling assumes the systems to be continuous and evolve deterministically. The behaviour of the system can be described using ODEs, which are then solved. However, such models ignore the phenomena that occur due to the fact that each system consists of a finite number of discrete particles, such as random fluctuations. For systems with very small particle numbers the deterministic models are not even appropriate because the concentrations are not continuous.</p><p>Stochastic modelling takes into account the fact that each system is composed of a finite and countable number of particles and considers the number of those particles similar to the way the deterministic system considers concentrations.</p><p><b>2. Drawbacks of stochastic modelling</b></p><p><b>2.1. Limits on particle numbers</b></p><p>Considering the fact that the number of particles in the system is very large, computational modelling of a stochastic method is very demanding and developing an algorithm is a complex task.</p><p><b>2.2. Lack of analysis methods</b></p><p>Stochastic modelling does not have such rigorously developed analysis methods as metabolic control analysis for deterministic modelling.</p><p><b>3. Drawbacks of deterministic modelling</b></p><p><b>3.1. Systems with small particle numbers</b></p><p>Stochastic methods consider random fluctuations which lead to significant change in system behaviour when the number of particles is small. Species are allowed to become extinct. In deterministic models the fluctuations are not accounted for and species concentrations never fall to zero. Therefore, in linear processes, the deterministic model behaviour will only be determined by difference in concentrations. The stochastic models can behave differently. This remains true even if stochastic systems have the same marginal distribution of system states.</p><p><b>3.2. Bi-Stable systems</b></p><p>Under deterministic simulation the system which is bi-stable will converge to the same stable steady state if the initial concentrations remain the same. Under stochastic simulation the system will converge to one of the two stable states, and it can not be predicted to which one. The probability of the system converging to each state, however, can be calculated.</p><p><b>4. Difference between the deterministic solution and the mean of stochastic solutions</b></p><p>It should be noted that if we repeat the stochastic simulation many times and calculate the mean, we will not end up with the same solution as the deterministic. This is only true for linear systems, but the solutions for nonlinear systems can be totally different.</p><p><b>5. Conclusion</b></p><p>Stochastic modelling should definitely be chosen when the particle numbers are in range where the concept of continuous concentration is no longer applicable or when the stochastic phenomena are themselves the object of research. The limit on the application of stochastic model is generally enforced at a certain particle number where computation becomes not feasible.</p><p><b>References</b></p><p>Pahle J, <i>Biochemical simulations: stochastic, approximate stochastic and hybrid approaches</i>, Briefings in Bioinformatics 2009, 10(1), pp 53-64</p><br>" + "by <a title= \"Evgeny\" rel=\"author\" href=\"https://plus.google.com/112677661119561622427?rel=author\" alt=\"Google+\" title=\"Google+\">Evgeny</a>";
public const string content_13072013_d = "Description of the purpose of stochastic modelling and simulation approaches in comparison with deterministic modelling using ordinary differential equations.";
public const string content_13072013_k = "stochastic deterministic modelling biochemical simulations";

    }
}