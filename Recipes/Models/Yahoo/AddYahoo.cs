using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace Recipes.Models.Yahoo
{
    public static class AddYahoo
    {
        public static void AddSymbols(RecipesEntities context)
        {
            try
            {
                string goog =
                    @"<p>Google is a global technology leader focused on improving the ways people connect with information. The company's innovations in web search and advertising have made its web site a top internet property and its brand one of the most recognized in the world. Google maintains a large index of web sites and other online content, which it makes freely available via its search engine to anyone with an internet connection. Its automated search technology helps people obtain nearly instant access to relevant information from its vast online index.</p>
                <p>Google generates revenue primarily by delivering relevant, cost-effective online advertising. Businesses use its AdWords program to promote their products and services with targeted advertising. In addition, the third-party web sites that comprise the Google Network use Google's AdSense program to deliver relevant ads that generate revenue and enhance the user experience.</p>
                <p>Google was incorporated in California in September 1998 and reincorporated in Delaware in August 2003. Its headquarters are located at 1600 Amphitheatre Parkway, Mountain View, California 94043, and telephone number is (650) 253-0000.</p>
                <p>At December 31, 2009, we had 19,835 employees, consisting of 7,443 in research and development, 7,338 in sales and marketing, 2,941 in general and administrative and 2,113 in operations. All of Google’s employees are also equityholders, with significant collective employee ownership.</p>";

                string aapl = @"<p>Apple Inc. and its wholly-owned subsidiaries (collectively “Apple” or the “Company”) design, manufacture, and market personal computers, mobile communication devices, and portable digital music and video players and sell a variety of related software, services, peripherals, and networking solutions. The Company sells its products worldwide through its online stores, its retail stores, its direct sales force, and third-party wholesalers, resellers, and value-added resellers. In addition, the Company sells a variety of third-party Macintosh® (“Mac”), iPhone® and iPod® compatible products, including application software, printers, storage devices, speakers, headphones, and various other accessories and peripherals through its online and retail stores, and digital content and applications through the iTunes Store®. The Company sells to consumer, small and mid-sized business (“SMB”), education, enterprise, government and creative customers. The Company’s fiscal year is the 52 or 53-week period that ends on the last Saturday of September.</p>";

                string msft = @"<p>Our mission is to enable people and businesses throughout the world to realize their full potential. Since the company was founded in 1975, we have worked to achieve this mission by creating technology that transforms the way people work, play, and communicate. We develop and market software, services, hardware, and solutions that we believe deliver new opportunities, greater convenience, and enhanced value to people’s lives. We do business throughout the world and have offices in more than 100 countries.</p>
                <p>We generate revenue by developing, manufacturing, licensing, and supporting a wide range of software products and services for many different types of computing devices. Our software products and services include operating systems for servers, personal computers, and intelligent devices; server applications for distributed computing environments; information worker productivity applications; business solutions applications; high-performance computing applications; software development tools; and video games. We provide consulting and product and solution support services, and we train and certify computer system integrators and developers. We also design and sell hardware including the Xbox 360 video game console, the Zune digital music and entertainment device, and peripherals. Online offerings and information are delivered through Bing, Windows Live, Office Live, our MSN portals and channels, and the Microsoft Online Services platform which includes offerings for businesses such as Microsoft Dynamics CRM Online, Exchange Hosted Services, Exchange Online, and SharePoint Online. We enable the delivery of online advertising across our broad range of digital media properties and on Bing through our proprietary adCenter platform.</p>
                <p>We also conduct research and develop advanced technologies for future software products and services. We believe that delivering breakthrough innovation and high-value solutions through our integrated software platform is the key to meeting our customers’ needs and to our future growth. We believe that we will continue to lay the foundation for long-term growth by delivering new products and services, creating new opportunities for partners, improving customer satisfaction, and improving our internal processes. Our focus is to build on this foundation through ongoing innovation in our integrated software platforms; by delivering compelling value propositions to customers; by responding effectively to customer and partner needs; and by continuing to emphasize the importance of product excellence, business efficacy, and accountability.</p>";

                string yhoo = @"<p>Yahoo! Inc., together with its consolidated subsidiaries (“Yahoo!,” the “Company,” “we,” or “us”), attracts hundreds of millions of users every month through its innovative technology and engaging content and services, making it one of the most trafficked Internet destinations and a world class online media company. Yahoo!’s vision is to be the center of people’s online lives by delivering personally relevant, meaningful Internet experiences. To users, we provide online properties and services (“Yahoo! Properties” or our “Owned and Operated sites”). To advertisers, we provide a range of marketing services designed to reach and connect with users of our Owned and Operated sites, as well as with Internet users beyond Yahoo! Properties, through a distribution network of third-party entities (our “Affiliates”) that have integrated our advertising offerings into their Websites, referred to as Affiliate sites, or their other offerings. We believe that our marketing services enable advertisers to deliver highly relevant marketing messages to their target audiences.<p>
                <p>We generate revenues by providing marketing services to advertisers across a majority of Yahoo! Properties and Affiliate sites. Our marketing services offerings include the display of graphical advertisements (“display advertising”), the display of text-based links to an advertiser’s Website (“search advertising”), listing-based services, and commerce-based transactions. Additionally, although many of the services we provide to users are free, we charge fees for a number of premium services.<p>
                <p>Our offerings to users on Yahoo! Properties currently fall into four categories: Integrated Consumer Experiences, Applications (Communications and Communities), Search, and Media Products and Solutions. The majority of our offerings are available in more than 25 languages.<p>
                <p>Yahoo! was developed and first made available in 1994 by our founders, David Filo and Jerry Yang, while they were graduate students at Stanford University. We were incorporated in 1995 and are a Delaware corporation. We are headquartered in Sunnyvale, California, and have offices in more than 25 countries, regions, and territories.</p>";

                List<YahooSymbol> symbols = new List<YahooSymbol>

                                                {
                                                    new YahooSymbol {YahooSymbolID = 1, YahooSymbolName = "GOOG", SymbolDescription = goog, SymbolName = "Google", WebSite = "http://www.google.com"},
                                                    new YahooSymbol {YahooSymbolID = 2, YahooSymbolName = "AAPL", SymbolDescription = aapl, SymbolName = "Apple", WebSite = "http://www.apple.com"},
                                                    new YahooSymbol {YahooSymbolID = 3, YahooSymbolName = "MSFT", SymbolDescription = msft, SymbolName = "Microsoft", WebSite = "http://www.microsoft.com"},
                                                    new YahooSymbol {YahooSymbolID = 4, YahooSymbolName = "YHOO", SymbolDescription = yhoo, SymbolName = "Yahoo", WebSite = "http://www.yahoo.com"}
                                                };

                symbols.ForEach(p => context.YahooSymbols.Add(p));
                context.SaveChanges();
            }
            catch (DbEntityValidationException vex)
            {
                foreach (var err in vex.EntityValidationErrors)
                {
                    foreach (var err2 in err.ValidationErrors)
                    {
                        string msg = err2.ErrorMessage;
                    }
                }
            }
        }
    }
}
