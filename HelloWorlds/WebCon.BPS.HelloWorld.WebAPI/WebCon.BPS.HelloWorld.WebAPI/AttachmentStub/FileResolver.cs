using System;
using System.IO;

namespace WebCon.BPS.HelloWorld.WebAPI.AttachmentStub
{
    class FileResolver
    {
        public static byte[] GetStubFileBytes()
        {
            byte[] result;
            using (FileStream stream = new FileStream(@".\AttachmentStub\image.jpg", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    result = reader.ReadBytes((int)stream.Length);

                    reader.Close();
                    stream.Close();
                }
            }

            return result;
        }
    }
}
