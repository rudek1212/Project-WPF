using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektNaPO
{
    public class Serialization
    {
        static public List<Product> Deserialize(string path)
        {
            if (File.Exists(path))
            {
                FileStream MyStream;
                BinaryFormatter MyFormatter = new BinaryFormatter();
                List<Product> productList;

                //deserializacja
                MyStream = new FileStream(path, FileMode.Open);
                productList = (List<Product>)MyFormatter.Deserialize(MyStream);
                MyStream.Close();
                return productList;
            }
            MessageBox.Show("Database not found. Created new one.");
            List<Product> emptyProductList = new List<Product>();
            Serialize(emptyProductList, path);
            return emptyProductList;
        }
        static public void Serialize(List<Product> produkty, string path)
        {
            FileStream MyStream;
            BinaryFormatter MyFormatter = new BinaryFormatter();

            //serializacja
            MyStream = new FileStream(path, FileMode.Create);
            MyFormatter.Serialize(MyStream, produkty);
            MyStream.Close();
        }
    }
}
