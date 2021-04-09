using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApp1.Model;

namespace WpfApp1.Repositori
{
    public class Implimentation : Interface//толко внутри этой сборки
    {
        public static readonly string baseURL;
        public static Dictionary<String, Curs> kash;

        static Implimentation()//строка подключения
        {
            kash = new Dictionary<string, Curs>();
            baseURL = @"http://www.cbr.ru/scripts/XML_daily.asp";
        }
        public async Task<Curs> GetCurs()//при не выборе даты, относительно которой заполняются данные валют
        {
            return await GetCurs(null);
        }

        public async Task<Curs> GetCurs(DateTime? date)
        {
            if (date != null)
            {
                if (kash.ContainsKey(date.Value.ToShortDateString()))
                {
                    return kash[date.Value.ToShortDateString()];
                }
            }

            string reqURL = date == null ? baseURL : $"{ baseURL}?date_rec={date.Value.ToShortDateString()}";//содгие строки подключения при полученной дате

            var request = (HttpWebRequest)WebRequest.Create(reqURL);//создание запроса
            var response = (HttpWebResponse)request.GetResponse();//получение ответа

            if (response.StatusCode == HttpStatusCode.OK)
                using (Stream response_stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(response_stream, Encoding.GetEncoding(1251)))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Curs));
                        Curs curs = (Curs)serializer.Deserialize(reader);//десериализация запроса

                        curs.Valute.Add(new Valute(1, "Рубль РФ", 1));//добавляем рубль

                        if (!kash.ContainsKey(curs.Date))
                        {
                            kash.Add(curs.Date, curs);
                        }
                        return curs;
                    }
                }
            else
                Console.WriteLine(response.StatusCode);
            return null;
        }
    }
}
