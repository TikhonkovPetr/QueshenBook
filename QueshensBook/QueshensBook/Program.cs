using System.Text.Json;
using System.Text.Json.Nodes;

namespace QueshensBook
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (File.Exists("C:\\Users\\StudentApple\\Desktop\\QueshensBook\\SaveQue.json"))
            {
                using (FileStream Fill = new FileStream("C:\\Users\\StudentApple\\Desktop\\QueshensBook\\SaveQue.json", FileMode.Open))
                {
                    var mas = JsonSerializer.Deserialize<List<Qusen>>(Fill);
                    if (mas != null)
                        foreach (Qusen qq in mas)
                        {
                            InnerQusen.qusens.Add(qq);
                        }
                }
            }
            else
            {
                using (FileStream Fill = new FileStream("C:\\Users\\StudentApple\\Desktop\\QueshensBook\\SaveQue.json", FileMode.OpenOrCreate))
                {
                    List<Qusen> qq=new List<Qusen> { };
                    JsonSerializer.Serialize(Fill, qq);
                }
            }
            Application.Run(new Form1());
        }
    }
}