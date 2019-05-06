using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De.Kjg.Diversity.Impl.Utils
{
    public class StringUtil
    {
        public static List<string> ToChunks(string str, int chunkSize)
        {
            var ret = new List<string>();

            var length = str.Length;
            var offset = 0;

            while (offset < length)
            {
                ret.Add(str.Substring(offset, Math.Min(chunkSize, length - offset)));
                offset += chunkSize;
            }

            return ret;
        }

        public static string Join(List<string> chunks, string glue)
        {
            var sb = new StringBuilder();

            var count = chunks.Count();
            for (var i = 0; i < count; i++)
            {
                if (i > 0)
                    sb.Append(glue);
                sb.Append(chunks[i]);
            }

            return sb.ToString();
        }
    }
}
