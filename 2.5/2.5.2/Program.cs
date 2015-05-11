using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
 
namespace _2._5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = Type.GetTypeFromProgID("Word.Application");
            dynamic w = Activator.CreateInstance(t);

            w.Visible = true;
            w.Documents.Add();

            Word.Application word = new Word.Application();
            word.ShowAnimation = false;
            word.Visible = false;

            object missing = System.Reflection.Missing.Value;

            Word.Document document = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            document.Content.Text = "Programowanie pod Windows";

            object filename = @"C:\Users\Szymon\Desktop\ppw.doc";
            document.SaveAs2(ref filename);
            document.Close(ref missing, ref missing, ref missing);
            document = null;

            word.Quit(ref missing, ref missing, ref missing);
            word = null;
        }
    }
}
