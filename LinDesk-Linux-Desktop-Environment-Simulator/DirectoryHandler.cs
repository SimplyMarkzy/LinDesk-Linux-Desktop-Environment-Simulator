using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class DirectoryHandler
    {
        public DirectoryConstructor Root { get; }
        public DirectoryConstructor Home { get; }
        public FileConstructor Test { get; }
        public DirectoryHandler()
        {
            Root = new DirectoryConstructor("/", null); //root directory
            Home = new DirectoryConstructor("home", Root);
            Root.SubDirectories.Add(Home);
            Test = new FileConstructor("test.txt");
            Test.Content = "This is a test file.";
            Root.Files.Add(Test);
            FileConstructor Test1 = new FileConstructor("test1.txt");
            Root.Files.Add(Test1);

            FileConstructor Test2 = new FileConstructor("test2.txt");
            Root.Files.Add(Test2);

            FileConstructor Test3 = new FileConstructor("test3.txt");
            Root.Files.Add(Test3);

            FileConstructor Test4 = new FileConstructor("test4.txt");
            Root.Files.Add(Test4);

            FileConstructor Test5 = new FileConstructor("test5.txt");
            Root.Files.Add(Test5);

            FileConstructor Test6 = new FileConstructor("test6.txt");
            Root.Files.Add(Test6);

            FileConstructor Test7 = new FileConstructor("test7.txt");
            Root.Files.Add(Test7);

            FileConstructor Test8 = new FileConstructor("test8.txt");
            Root.Files.Add(Test8);

            FileConstructor Test9 = new FileConstructor("test9.txt");
            Root.Files.Add(Test9);

            FileConstructor Test10 = new FileConstructor("test10.txt");
            Root.Files.Add(Test10);

            FileConstructor Test11 = new FileConstructor("test11.txt");
            Root.Files.Add(Test11);

            FileConstructor Test12 = new FileConstructor("test12.txt");
            Root.Files.Add(Test12);

            FileConstructor Test13 = new FileConstructor("test13.txt");
            Root.Files.Add(Test13);

            FileConstructor Test14 = new FileConstructor("test14.txt");
            Root.Files.Add(Test14);

            FileConstructor Test15 = new FileConstructor("test15.txt");
            Root.Files.Add(Test15);

            FileConstructor Test16 = new FileConstructor("test16.txt");
            Root.Files.Add(Test16);

            FileConstructor Test17 = new FileConstructor("test17.txt");
            Root.Files.Add(Test17);

            FileConstructor Test18 = new FileConstructor("test18.txt");
            Root.Files.Add(Test18);

            FileConstructor Test19 = new FileConstructor("test19.txt");
            Root.Files.Add(Test19);

            FileConstructor Test20 = new FileConstructor("test20.txt");
            Root.Files.Add(Test20);

            FileConstructor Test21 = new FileConstructor("test21.txt");
            Root.Files.Add(Test21);

            FileConstructor Test22 = new FileConstructor("test22.txt");
            Root.Files.Add(Test22);

            FileConstructor Test23 = new FileConstructor("test23.txt");
            Root.Files.Add(Test23);

            FileConstructor Test24 = new FileConstructor("test24.txt");
            Root.Files.Add(Test24);

            FileConstructor Test25 = new FileConstructor("test25.txt");
            Root.Files.Add(Test25);

            FileConstructor Test26 = new FileConstructor("test26.txt");
            Root.Files.Add(Test26);

            FileConstructor Test27 = new FileConstructor("test27.txt");
            Root.Files.Add(Test27);

            FileConstructor Test28 = new FileConstructor("test28.txt");
            Root.Files.Add(Test28);

            FileConstructor Test29 = new FileConstructor("test29.txt");
            Root.Files.Add(Test29);

            FileConstructor Test30 = new FileConstructor("test30.txt");
            Root.Files.Add(Test30);

            FileConstructor Test31 = new FileConstructor("test31.txt");
            Root.Files.Add(Test31);

            FileConstructor Test32 = new FileConstructor("test32.txt");
            Root.Files.Add(Test32);

            FileConstructor Test33 = new FileConstructor("test33.txt");
            Root.Files.Add(Test33);

            FileConstructor Test34 = new FileConstructor("test34.txt");
            Root.Files.Add(Test34);

            FileConstructor Test35 = new FileConstructor("test35.txt");
            Root.Files.Add(Test35);

            FileConstructor Test36 = new FileConstructor("test36.txt");
            Root.Files.Add(Test36);

            FileConstructor Test37 = new FileConstructor("test37.txt");
            Root.Files.Add(Test37);

            FileConstructor Test38 = new FileConstructor("test38.txt");
            Root.Files.Add(Test38);

            FileConstructor Test39 = new FileConstructor("test39.txt");
            Root.Files.Add(Test39);

            FileConstructor Test40 = new FileConstructor("test40.txt");
            Root.Files.Add(Test40);

            FileConstructor Test41 = new FileConstructor("test41.txt");
            Root.Files.Add(Test41);

            FileConstructor Test42 = new FileConstructor("test42.txt");
            Root.Files.Add(Test42);

            FileConstructor Test43 = new FileConstructor("test43.txt");
            Root.Files.Add(Test43);

            FileConstructor Test44 = new FileConstructor("test44.txt");
            Root.Files.Add(Test44);

            FileConstructor Test45 = new FileConstructor("test45.txt");
            Root.Files.Add(Test45);

            FileConstructor Test46 = new FileConstructor("test46.txt");
            Root.Files.Add(Test46);

            FileConstructor Test47 = new FileConstructor("test47.txt");
            Root.Files.Add(Test47);

            FileConstructor Test48 = new FileConstructor("test48.txt");
            Root.Files.Add(Test48);

            FileConstructor Test49 = new FileConstructor("test49.txt");
            Root.Files.Add(Test49);

            FileConstructor Test50 = new FileConstructor("test50.txt");
            Root.Files.Add(Test50);

            FileConstructor Test51 = new FileConstructor("test51.txt");
            Root.Files.Add(Test51);

            FileConstructor Test52 = new FileConstructor("test52.txt");
            Root.Files.Add(Test52);

            FileConstructor Test53 = new FileConstructor("test53.txt");
            Root.Files.Add(Test53);

            FileConstructor Test54 = new FileConstructor("test54.txt");
            Root.Files.Add(Test54);

            FileConstructor Test55 = new FileConstructor("test55.txt");
            Root.Files.Add(Test55);

            FileConstructor Test56 = new FileConstructor("test56.txt");
            Root.Files.Add(Test56);

            FileConstructor Test57 = new FileConstructor("test57.txt");
            Root.Files.Add(Test57);

            FileConstructor Test58 = new FileConstructor("test58.txt");
            Root.Files.Add(Test58);

            FileConstructor Test59 = new FileConstructor("test59.txt");
            Root.Files.Add(Test59);

            FileConstructor Test60 = new FileConstructor("test60.txt");
            Root.Files.Add(Test60);

            FileConstructor Test61 = new FileConstructor("test61.txt");
            Root.Files.Add(Test61);

            FileConstructor Test62 = new FileConstructor("test62.txt");
            Root.Files.Add(Test62);

            FileConstructor Test63 = new FileConstructor("test63.txt");
            Root.Files.Add(Test63);

            FileConstructor Test64 = new FileConstructor("test64.txt");
            Root.Files.Add(Test64);

            FileConstructor Test65 = new FileConstructor("test65.txt");
            Root.Files.Add(Test65);

            FileConstructor Test66 = new FileConstructor("test66.txt");
            Root.Files.Add(Test66);

            FileConstructor Test67 = new FileConstructor("test67.txt");
            Root.Files.Add(Test67);

            FileConstructor Test68 = new FileConstructor("test68.txt");
            Root.Files.Add(Test68);

            FileConstructor Test69 = new FileConstructor("test69.txt");
            Root.Files.Add(Test69);

            FileConstructor Test70 = new FileConstructor("test70.txt");
            Root.Files.Add(Test70);

            FileConstructor Test71 = new FileConstructor("test71.txt");
            Root.Files.Add(Test71);

            FileConstructor Test72 = new FileConstructor("test72.txt");
            Root.Files.Add(Test72);

            FileConstructor Test73 = new FileConstructor("test73.txt");
            Root.Files.Add(Test73);

            FileConstructor Test74 = new FileConstructor("test74.txt");
            Root.Files.Add(Test74);

            FileConstructor Test75 = new FileConstructor("test75.txt");
            Root.Files.Add(Test75);

            FileConstructor Test76 = new FileConstructor("test76.txt");
            Root.Files.Add(Test76);

            FileConstructor Test77 = new FileConstructor("test77.txt");
            Root.Files.Add(Test77);

            FileConstructor Test78 = new FileConstructor("test78.txt");
            Root.Files.Add(Test78);

            FileConstructor Test79 = new FileConstructor("test79.txt");
            Root.Files.Add(Test79);

            FileConstructor Test80 = new FileConstructor("test80.txt");
            Root.Files.Add(Test80);

            FileConstructor Test81 = new FileConstructor("test81.txt");
            Root.Files.Add(Test81);

            FileConstructor Test82 = new FileConstructor("test82.txt");
            Root.Files.Add(Test82);

            FileConstructor Test83 = new FileConstructor("test83.txt");
            Root.Files.Add(Test83);

            FileConstructor Test84 = new FileConstructor("test84.txt");
            Root.Files.Add(Test84);

            FileConstructor Test85 = new FileConstructor("test85.txt");
            Root.Files.Add(Test85);

            FileConstructor Test86 = new FileConstructor("test86.txt");
            Root.Files.Add(Test86);

            FileConstructor Test87 = new FileConstructor("test87.txt");
            Root.Files.Add(Test87);

            FileConstructor Test88 = new FileConstructor("test88.txt");
            Root.Files.Add(Test88);

            FileConstructor Test89 = new FileConstructor("test89.txt");
            Root.Files.Add(Test89);

            FileConstructor Test90 = new FileConstructor("test90.txt");
            Root.Files.Add(Test90);

            FileConstructor Test91 = new FileConstructor("test91.txt");
            Root.Files.Add(Test91);

            FileConstructor Test92 = new FileConstructor("test92.txt");
            Root.Files.Add(Test92);

            FileConstructor Test93 = new FileConstructor("test93.txt");
            Root.Files.Add(Test93);

            FileConstructor Test94 = new FileConstructor("test94.txt");
            Root.Files.Add(Test94);

            FileConstructor Test95 = new FileConstructor("test95.txt");
            Root.Files.Add(Test95);

            FileConstructor Test96 = new FileConstructor("test96.txt");
            Root.Files.Add(Test96);

            FileConstructor Test97 = new FileConstructor("test97.txt");
            Root.Files.Add(Test97);

            FileConstructor Test98 = new FileConstructor("test98.txt");
            Root.Files.Add(Test98);

            FileConstructor Test99 = new FileConstructor("test99.txt");
            Root.Files.Add(Test99);

            FileConstructor Test100 = new FileConstructor("test100.txt");
            Root.Files.Add(Test100);
            DirectoryConstructor Folder1 = new DirectoryConstructor("Folder1", Root);
            Root.SubDirectories.Add(Folder1);

            DirectoryConstructor Folder2 = new DirectoryConstructor("Folder2", Root);
            Root.SubDirectories.Add(Folder2);

            DirectoryConstructor Folder3 = new DirectoryConstructor("Folder3", Root);
            Root.SubDirectories.Add(Folder3);

            DirectoryConstructor Folder4 = new DirectoryConstructor("Folder4", Root);
            Root.SubDirectories.Add(Folder4);

            DirectoryConstructor Folder5 = new DirectoryConstructor("Folder5", Root);
            Root.SubDirectories.Add(Folder5);

            DirectoryConstructor Folder6 = new DirectoryConstructor("Folder6", Root);
            Root.SubDirectories.Add(Folder6);

            DirectoryConstructor Folder7 = new DirectoryConstructor("Folder7", Root);
            Root.SubDirectories.Add(Folder7);

            DirectoryConstructor Folder8 = new DirectoryConstructor("Folder8", Root);
            Root.SubDirectories.Add(Folder8);

            DirectoryConstructor Folder9 = new DirectoryConstructor("Folder9", Root);
            Root.SubDirectories.Add(Folder9);

            DirectoryConstructor Folder10 = new DirectoryConstructor("Folder10", Root);
            Root.SubDirectories.Add(Folder10);

            DirectoryConstructor Folder11 = new DirectoryConstructor("Folder11", Root);
            Root.SubDirectories.Add(Folder11);

            DirectoryConstructor Folder12 = new DirectoryConstructor("Folder12", Root);
            Root.SubDirectories.Add(Folder12);

            DirectoryConstructor Folder13 = new DirectoryConstructor("Folder13", Root);
            Root.SubDirectories.Add(Folder13);

            DirectoryConstructor Folder14 = new DirectoryConstructor("Folder14", Root);
            Root.SubDirectories.Add(Folder14);

            DirectoryConstructor Folder15 = new DirectoryConstructor("Folder15", Root);
            Root.SubDirectories.Add(Folder15);

            DirectoryConstructor Folder16 = new DirectoryConstructor("Folder16", Root);
            Root.SubDirectories.Add(Folder16);

            DirectoryConstructor Folder17 = new DirectoryConstructor("Folder17", Root);
            Root.SubDirectories.Add(Folder17);

            DirectoryConstructor Folder18 = new DirectoryConstructor("Folder18", Root);
            Root.SubDirectories.Add(Folder18);

            DirectoryConstructor Folder19 = new DirectoryConstructor("Folder19", Root);
            Root.SubDirectories.Add(Folder19);

            DirectoryConstructor Folder20 = new DirectoryConstructor("Folder20", Root);
            Root.SubDirectories.Add(Folder20);

            DirectoryConstructor Folder21 = new DirectoryConstructor("Folder21", Root);
            Root.SubDirectories.Add(Folder21);

            DirectoryConstructor Folder22 = new DirectoryConstructor("Folder22", Root);
            Root.SubDirectories.Add(Folder22);

            DirectoryConstructor Folder23 = new DirectoryConstructor("Folder23", Root);
            Root.SubDirectories.Add(Folder23);

            DirectoryConstructor Folder24 = new DirectoryConstructor("Folder24", Root);
            Root.SubDirectories.Add(Folder24);

            DirectoryConstructor Folder25 = new DirectoryConstructor("Folder25", Root);
            Root.SubDirectories.Add(Folder25);

            DirectoryConstructor Folder26 = new DirectoryConstructor("Folder26", Root);
            Root.SubDirectories.Add(Folder26);

            DirectoryConstructor Folder27 = new DirectoryConstructor("Folder27", Root);
            Root.SubDirectories.Add(Folder27);

            DirectoryConstructor Folder28 = new DirectoryConstructor("Folder28", Root);
            Root.SubDirectories.Add(Folder28);

            DirectoryConstructor Folder29 = new DirectoryConstructor("Folder29", Root);
            Root.SubDirectories.Add(Folder29);

            DirectoryConstructor Folder30 = new DirectoryConstructor("Folder30", Root);
            Root.SubDirectories.Add(Folder30);

            DirectoryConstructor Folder31 = new DirectoryConstructor("Folder31", Root);
            Root.SubDirectories.Add(Folder31);

            DirectoryConstructor Folder32 = new DirectoryConstructor("Folder32", Root);
            Root.SubDirectories.Add(Folder32);

            DirectoryConstructor Folder33 = new DirectoryConstructor("Folder33", Root);
            Root.SubDirectories.Add(Folder33);

            DirectoryConstructor Folder34 = new DirectoryConstructor("Folder34", Root);
            Root.SubDirectories.Add(Folder34);

            DirectoryConstructor Folder35 = new DirectoryConstructor("Folder35", Root);
            Root.SubDirectories.Add(Folder35);

            DirectoryConstructor Folder36 = new DirectoryConstructor("Folder36", Root);
            Root.SubDirectories.Add(Folder36);

            DirectoryConstructor Folder37 = new DirectoryConstructor("Folder37", Root);
            Root.SubDirectories.Add(Folder37);

            DirectoryConstructor Folder38 = new DirectoryConstructor("Folder38", Root);
            Root.SubDirectories.Add(Folder38);

            DirectoryConstructor Folder39 = new DirectoryConstructor("Folder39", Root);
            Root.SubDirectories.Add(Folder39);

            DirectoryConstructor Folder40 = new DirectoryConstructor("Folder40", Root);
            Root.SubDirectories.Add(Folder40);

            DirectoryConstructor Folder41 = new DirectoryConstructor("Folder41", Root);
            Root.SubDirectories.Add(Folder41);

            DirectoryConstructor Folder42 = new DirectoryConstructor("Folder42", Root);
            Root.SubDirectories.Add(Folder42);

            DirectoryConstructor Folder43 = new DirectoryConstructor("Folder43", Root);
            Root.SubDirectories.Add(Folder43);

            DirectoryConstructor Folder44 = new DirectoryConstructor("Folder44", Root);
            Root.SubDirectories.Add(Folder44);

            DirectoryConstructor Folder45 = new DirectoryConstructor("Folder45", Root);
            Root.SubDirectories.Add(Folder45);

            DirectoryConstructor Folder46 = new DirectoryConstructor("Folder46", Root);
            Root.SubDirectories.Add(Folder46);

            DirectoryConstructor Folder47 = new DirectoryConstructor("Folder47", Root);
            Root.SubDirectories.Add(Folder47);

            DirectoryConstructor Folder48 = new DirectoryConstructor("Folder48", Root);
            Root.SubDirectories.Add(Folder48);

            DirectoryConstructor Folder49 = new DirectoryConstructor("Folder49", Root);
            Root.SubDirectories.Add(Folder49);

            DirectoryConstructor Folder50 = new DirectoryConstructor("Folder50", Root);
            Root.SubDirectories.Add(Folder50);
        }
    }
}
