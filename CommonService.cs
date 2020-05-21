using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK
{
    public class CommonService
    {
        public static T JsonDeSerializer<T>(string jsonString) where T : class
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return null;
            }
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(jsonString));

                T obj = (T)js.ReadObject(ms);

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while Serializing json object", ex);
            }
        }

        public static string JsonSerializer<T>(T entity) where T : class
        {
            try
            {
                ////serialize a .NET object to JSON using DataContractJsonSerializer           
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
                DataContractJsonSerializerSettings s = new DataContractJsonSerializerSettings();
                ds.WriteObject(stream, entity);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error while DeSerializing object", ex);
            }
        }
    }
}
