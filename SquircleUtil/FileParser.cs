using System.Text;

namespace SquircleUtil
{
    internal class FileParser
    {
        public byte[] Buffer;
        public int Pointer;
        public long Length;

        public FileParser(string path)
        {

            using (var file = File.Open(path, FileMode.Open))
            {
                Buffer = new byte[file.Length];
                Pointer = 0;
                file.Read(Buffer);
            }
        }

        public FileParser(byte[] buffer)
        {
            Length = buffer.Length;
            Buffer = buffer;
            Pointer = 0;
        }

        public byte[] Get(int length)
        {
            Pointer += length;
            return Buffer[(Pointer - length)..Pointer];
        }

        public void Skip(int length)
        {
            Pointer += length;
        }

        public void Seek(int pointer)
        {
            Pointer = pointer;
        }

        public string GetLine()
        {
            var line = String.Empty;

            while (true)
            {
                Pointer++;
                var character = Encoding.UTF8.GetString(Buffer, Pointer - 1, 1);

                if (character == "\n")
                    break;

                line += character;
            }

            return line;
        }

        public string GetString(int length)
        {
            Pointer += length;
            return Encoding.UTF8.GetString(Buffer, Pointer - length, length);
        }

        public bool GetBool()
        {
            Pointer += 1;
            return BitConverter.ToBoolean(Buffer, Pointer - 1);
        }

        public float GetFloat()
        {
            Pointer += 4;
            return BitConverter.ToSingle(Buffer, Pointer - 4);
        }

        public double GetDouble()
        {
            Pointer += 8;
            return BitConverter.ToDouble(Buffer, Pointer - 8);
        }

        public ushort GetUInt8()
        {
            return Get(1)[0];
        }

        public ushort GetUInt16()
        {
            Pointer += 2;
            return BitConverter.ToUInt16(Buffer, Pointer - 2);
        }

        public uint GetUInt32()
        {
            Pointer += 4;
            return BitConverter.ToUInt32(Buffer, Pointer - 4);
        }

        public ulong GetUInt64()
        {
            Pointer += 8;
            return BitConverter.ToUInt64(Buffer, Pointer - 8);
        }
    }
}
