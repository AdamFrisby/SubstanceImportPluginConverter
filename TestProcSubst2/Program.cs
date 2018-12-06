using System;
using ProcSubstanceEditor;

namespace TestProcSubst2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("ID: " + ProcSubstanceEditor.FileIDUtil.ComputeSubstanceName("bricks_032"));
            //Console.ReadKey();


            SubstanceMetaFileConverter.ConvertFile(
                "C:\\Users\\adam\\Projects\\Substances\\Substances Test\\Assets\\Substances\\bricks_032.sbsar - Original.txt",
                "D:\\TestBricks32.sbsar.meta");


        }
    }
}