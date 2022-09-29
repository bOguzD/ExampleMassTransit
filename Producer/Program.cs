using MassTransit;
using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Producer
{
    public class MessageTest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class Message : IMessage
    {
        public string Text { get; set; }
    }

    public class EmailEvent
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public string ProviderCode { get; set; }
        public string ReferenceNo { get; set; }
        public string TaxIdentityIdSender { get; set; }
        public string TaxIdentityIdReceiver { get; set; }
    }

    class Program
    {
        
        static async Task Main(string[] args)
        {
            string rabbitMqUri = "amqp://localhost";
            string queue = "test-jsondata";
            string userName = "guest";
            string password = "guest";

            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMqUri, configurator =>
                {
                    configurator.Username(userName);
                    configurator.Password(password);
                });
            });

            var sendToUri = new Uri($"{rabbitMqUri}/{queue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await Task.Run(async () =>
            {
                var x = true;
                while (x)
                {
                    #region data
                    var stringJsonData = @"[{'UserId':1,'FirstName':'Catlin','LastName':'Stirling','Email':'cstirling0@prnewswire.com'},
{'UserId':2,'FirstName':'Lacee','LastName':'Vaines','Email':'lvaines1@multiply.com'},
{'UserId':3,'FirstName':'Hedi','LastName':'Lowres','Email':'hlowres2@webnode.com'},
{'UserId':4,'FirstName':'Roddie','LastName':'Jouen','Email':'rjouen3@friendfeed.com'},
{'UserId':5,'FirstName':'Annmarie','LastName':'Hacker','Email':'ahacker4@sourceforge.net'},
{'UserId':6,'FirstName':'Glad','LastName':'Foister','Email':'gfoister5@princeton.edu'},
{'UserId':7,'FirstName':'Ezra','LastName':'Lennie','Email':'elennie6@cbsnews.com'},
{'UserId':8,'FirstName':'Jana','LastName':'Pindell','Email':'jpindell7@whitehouse.gov'},
{'UserId':9,'FirstName':'Enriqueta','LastName':'Seward','Email':'eseward8@google.com.au'},
{'UserId':10,'FirstName':'Parker','LastName':'Oriel','Email':'poriel9@tripadvisor.com'},
{'UserId':11,'FirstName':'Alyssa','LastName':'Tower','Email':'atowera@pcworld.com'},
{'UserId':12,'FirstName':'Dasha','LastName':'Janaway','Email':'djanawayb@mlb.com'},
{'UserId':13,'FirstName':'Belita','LastName':'Pinkstone','Email':'bpinkstonec@google.nl'},
{'UserId':14,'FirstName':'Murvyn','LastName':'Menicomb','Email':'mmenicombd@youtu.be'},
{'UserId':15,'FirstName':'Glenda','LastName':'Le Bosse','Email':'glebossee@netlog.com'},
{'UserId':16,'FirstName':'Peria','LastName':'Hanley','Email':'phanleyf@hatena.ne.jp'},
{'UserId':17,'FirstName':'Renell','LastName':'Maggi','Email':'rmaggig@dedecms.com'},
{'UserId':18,'FirstName':'Nadine','LastName':'Streatfeild','Email':'nstreatfeildh@photobucket.com'},
{'UserId':19,'FirstName':'Jessie','LastName':'MacAughtrie','Email':'jmacaughtriei@google.com.hk'},
{'UserId':20,'FirstName':'Frayda','LastName':'Bernadon','Email':'fbernadonj@shop-pro.jp'},
{'UserId':21,'FirstName':'Sarajane','LastName':'Ventum','Email':'sventumk@comcast.net'},
{'UserId':22,'FirstName':'Rena','LastName':'Cowerd','Email':'rcowerdl@yale.edu'},
{'UserId':23,'FirstName':'Bailie','LastName':'Petrasek','Email':'bpetrasekm@youtube.com'},
{'UserId':24,'FirstName':'Cy','LastName':'Lile','Email':'clilen@dmoz.org'},
{'UserId':25,'FirstName':'Wilmar','LastName':'Kee','Email':'wkeeo@shinystat.com'},
{'UserId':26,'FirstName':'Eldin','LastName':'Chippindale','Email':'echippindalep@walmart.com'},
{'UserId':27,'FirstName':'Anya','LastName':'Goodreid','Email':'agoodreidq@engadget.com'},
{'UserId':28,'FirstName':'Colver','LastName':'Linkin','Email':'clinkinr@oakley.com'},
{'UserId':29,'FirstName':'Rianon','LastName':'Gonzalez','Email':'rgonzalezs@drupal.org'},
{'UserId':30,'FirstName':'Mose','LastName':'Fellis','Email':'mfellist@si.edu'},
{'UserId':31,'FirstName':'Luigi','LastName':'Filtness','Email':'lfiltnessu@bbb.org'},
{'UserId':32,'FirstName':'Bernard','LastName':'Drinnan','Email':'bdrinnanv@accuweather.com'},
{'UserId':33,'FirstName':'Theo','LastName':'Fidilis','Email':'tfidilisw@bbc.co.uk'},
{'UserId':34,'FirstName':'Jethro','LastName':'Kerbler','Email':'jkerblerx@indiatimes.com'},
{'UserId':35,'FirstName':'Joli','LastName':'Arundale','Email':'jarundaley@storify.com'},
{'UserId':36,'FirstName':'Francoise','LastName':'Jerschke','Email':'fjerschkez@nasa.gov'},
{'UserId':37,'FirstName':'Doralyn','LastName':'Godridge','Email':'dgodridge10@shop-pro.jp'},
{'UserId':38,'FirstName':'Nikolas','LastName':'Petto','Email':'npetto11@fc2.com'},
{'UserId':39,'FirstName':'Rollo','LastName':'Gummoe','Email':'rgummoe12@shinystat.com'},
{'UserId':40,'FirstName':'Katharine','LastName':'Groarty','Email':'kgroarty13@craigslist.org'},
{'UserId':41,'FirstName':'Gilly','LastName':'Strafen','Email':'gstrafen14@discovery.com'},
{'UserId':42,'FirstName':'Marley','LastName':'Jurzyk','Email':'mjurzyk15@ox.ac.uk'},
{'UserId':43,'FirstName':'Ray','LastName':'Mahody','Email':'rmahody16@amazon.co.jp'},
{'UserId':44,'FirstName':'Chancey','LastName':'Duesbury','Email':'cduesbury17@youtu.be'},
{'UserId':45,'FirstName':'Gerta','LastName':'De Banke','Email':'gdebanke18@newyorker.com'},
{'UserId':46,'FirstName':'Laurene','LastName':'Claire','Email':'lclaire19@omniture.com'},
{'UserId':47,'FirstName':'Meier','LastName':'Blindt','Email':'mblindt1a@quantcast.com'},
{'UserId':48,'FirstName':'Sandye','LastName':'MacTeggart','Email':'smacteggart1b@furl.net'},
{'UserId':49,'FirstName':'Karlen','LastName':'McSperron','Email':'kmcsperron1c@opera.com'},
{'UserId':50,'FirstName':'Eric','LastName':'Seakin','Email':'eseakin1d@opera.com'},
{'UserId':51,'FirstName':'Emmanuel','LastName':'Testin','Email':'etestin1e@ed.gov'},
{'UserId':52,'FirstName':'Ladonna','LastName':'Chestle','Email':'lchestle1f@smugmug.com'},
{'UserId':53,'FirstName':'Aldwin','LastName':'Cordel','Email':'acordel1g@weebly.com'},
{'UserId':54,'FirstName':'Ulises','LastName':'Berkowitz','Email':'uberkowitz1h@dell.com'},
{'UserId':55,'FirstName':'Tye','LastName':'Prium','Email':'tprium1i@tiny.cc'},
{'UserId':56,'FirstName':'Maryann','LastName':'Collimore','Email':'mcollimore1j@fema.gov'},
{'UserId':57,'FirstName':'Krispin','LastName':'McOnie','Email':'kmconie1k@uol.com.br'},
{'UserId':58,'FirstName':'Shena','LastName':'OHear','Email':'sohear1l@parallels.com'},
{'UserId':59,'FirstName':'Berkley','LastName':'Galpin','Email':'bgalpin1m@nytimes.com'},
{'UserId':60,'FirstName':'Harlin','LastName':'Hurtic','Email':'hhurtic1n@newyorker.com'},
{'UserId':61,'FirstName':'Morna','LastName':'Muzzlewhite','Email':'mmuzzlewhite1o@marketwatch.com'},
{'UserId':62,'FirstName':'Dario','LastName':'Daviddi','Email':'ddaviddi1p@discovery.com'},
{'UserId':63,'FirstName':'Mariellen','LastName':'Andriessen','Email':'mandriessen1q@europa.eu'},
{'UserId':64,'FirstName':'Minda','LastName':'Langrish','Email':'mlangrish1r@purevolume.com'},
{'UserId':65,'FirstName':'Natassia','LastName':'Tegler','Email':'ntegler1s@t.co'},
{'UserId':66,'FirstName':'Linnie','LastName':'Renackowna','Email':'lrenackowna1t@house.gov'},
{'UserId':67,'FirstName':'Iago','LastName':'Rainville','Email':'irainville1u@google.co.jp'},
{'UserId':68,'FirstName':'Analiese','LastName':'Giller','Email':'agiller1v@ucoz.com'},
{'UserId':69,'FirstName':'Herb','LastName':'Mattschas','Email':'hmattschas1w@baidu.com'},
{'UserId':70,'FirstName':'Margaretha','LastName':'Mead','Email':'mmead1x@fotki.com'},
{'UserId':71,'FirstName':'Karine','LastName':'Edmons','Email':'kedmons1y@unesco.org'},
{'UserId':72,'FirstName':'Barr','LastName':'Freeberne','Email':'bfreeberne1z@fastcompany.com'},
{'UserId':73,'FirstName':'Skye','LastName':'Lay','Email':'slay20@cornell.edu'},
{'UserId':74,'FirstName':'Eba','LastName':'Bartolomeo','Email':'ebartolomeo21@cnbc.com'},
{'UserId':75,'FirstName':'Jose','LastName':'Done','Email':'jdone22@posterous.com'},
{'UserId':76,'FirstName':'Simone','LastName':'Parades','Email':'sparades23@wordpress.com'},
{'UserId':77,'FirstName':'Ruttger','LastName':'Pawfoot','Email':'rpawfoot24@webnode.com'},
{'UserId':78,'FirstName':'Cordi','LastName':'Woolstenholmes','Email':'cwoolstenholmes25@hostgator.com'},
{'UserId':79,'FirstName':'Damara','LastName':'Palek','Email':'dpalek26@reddit.com'},
{'UserId':80,'FirstName':'Koralle','LastName':'Darleston','Email':'kdarleston27@merriam-webster.com'},
{'UserId':81,'FirstName':'Milicent','LastName':'Yegorshin','Email':'myegorshin28@fotki.com'},
{'UserId':82,'FirstName':'Hew','LastName':'Burney','Email':'hburney29@adobe.com'},
{'UserId':83,'FirstName':'Kassandra','LastName':'Spacey','Email':'kspacey2a@issuu.com'},
{'UserId':84,'FirstName':'Travus','LastName':'Helleckas','Email':'thelleckas2b@vinaora.com'},
{'UserId':85,'FirstName':'Ralf','LastName':'Trice','Email':'rtrice2c@storify.com'},
{'UserId':86,'FirstName':'Jenifer','LastName':'Gollard','Email':'jgollard2d@narod.ru'},
{'UserId':87,'FirstName':'Rosalia','LastName':'Proppers','Email':'rproppers2e@live.com'},
{'UserId':88,'FirstName':'Dwain','LastName':'De Cruce','Email':'ddecruce2f@edublogs.org'},
{'UserId':89,'FirstName':'Carrissa','LastName':'Slimming','Email':'cslimming2g@digg.com'},
{'UserId':90,'FirstName':'Preston','LastName':'Prichard','Email':'pprichard2h@github.io'},
{'UserId':91,'FirstName':'Glad','LastName':'Dingwall','Email':'gdingwall2i@tinypic.com'},
{'UserId':92,'FirstName':'Ardys','LastName':'Anthony','Email':'aanthony2j@aboutads.info'},
{'UserId':93,'FirstName':'Lefty','LastName':'Brummitt','Email':'lbrummitt2k@ustream.tv'},
{'UserId':94,'FirstName':'Eleanor','LastName':'Cahillane','Email':'ecahillane2l@soundcloud.com'},
{'UserId':95,'FirstName':'Riki','LastName':'Sleney','Email':'rsleney2m@adobe.com'},
{'UserId':96,'FirstName':'Gunter','LastName':'Sims','Email':'gsims2n@nationalgeographic.com'},
{'UserId':97,'FirstName':'Ursola','LastName':'Sellars','Email':'usellars2o@aboutads.info'},
{'UserId':98,'FirstName':'Donella','LastName':'Atwood','Email':'datwood2p@virginia.edu'},
{'UserId':99,'FirstName':'Kingsly','LastName':'Usmar','Email':'kusmar2q@nasa.gov'},
{'UserId':100,'FirstName':'Elysia','LastName':'Senter','Email':'esenter2r@blogger.com'}]";
                    #endregion
                    var data = JsonConvert.DeserializeObject<List<MessageTest>>(stringJsonData);

                    var count = 1;
                    foreach (var item in data)
                    {
                        Message message = new Message();
                        message.Text = item.FirstName + " " + item.LastName;
                        await endPoint.Send<IMessage>(message);
                        Console.WriteLine("record " + count + " of " + data.Count + " id:" + item.UserId.ToString());
                        count++;
                    }
                    Console.WriteLine("Tekrar Göndermek için e ye bas");
                    var input = Console.ReadLine();
                    if (input == "e")
                        x = true;
                    else
                        x =  false;
                    
                    
                    
                    
                }
            });
        }
    }
}