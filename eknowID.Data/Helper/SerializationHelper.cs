using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace EknowIDData.Helper
{
    public class SerializationHelper
    {
        public static object XmlDeserializeFromString(string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }

        public static string XmlSerializeToString(object objectInstance)
        {
            try {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();

                using (TextWriter writer = new ExtentedStringWriter(sb, Encoding.UTF8)) {
                    
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
            } catch (Exception ex) {

                throw;
            }
            
        }
    }

    public sealed class ExtentedStringWriter : StringWriter {
        private readonly Encoding stringWriterEncoding;
        public ExtentedStringWriter(StringBuilder builder, Encoding desiredEncoding)
            : base(builder) {
            this.stringWriterEncoding = desiredEncoding;
        }

        public override Encoding Encoding {
            get {
                return this.stringWriterEncoding;
            }
        }
    }
}
