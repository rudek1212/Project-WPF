using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace ProjektNaPO
{
    public class Serialization
    {
        public static List<Product> Deserialize(string path)
        {
            if (File.Exists(path))
            {
                var myFormatter = new BinaryFormatter();
                List<Product> productList;

                //deserializacja
                var myStream = new FileStream(path, FileMode.Open);
                productList = (List<Product>) myFormatter.Deserialize(myStream);
                myStream.Close();
                return productList;
            }
            MessageBox.Show("Database not found. Created new one.");
            var emptyProductList = new List<Product>();
            Serialize(emptyProductList, path);
            return emptyProductList;
        }

        public static void Serialize(List<Product> produkty, string path)
        {
            var myFormatter = new BinaryFormatter();

            //serializacja
            var myStream = new FileStream(path, FileMode.Create);
            myFormatter.Serialize(myStream, produkty);
            myStream.Close();
        }
    }
}