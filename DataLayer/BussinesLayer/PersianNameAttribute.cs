using System;

namespace DataLayer.BussinesLayer
{

    public static partial class PersianNameAttribute
    {
        public class PersianName : Attribute
        {
            public readonly string Text;

            public PersianName(string text)
            {
                Text = text;
            }
        }
    }

    public static partial class LocalFilePathAttribute
    {
        public class LocalFilePath : Attribute
        {
            public readonly string Text;

            public LocalFilePath(string text)
            {
                Text = text;
            }
        }
    }

    public static partial class RemoteFilePathAttribute
    {
        public class RemoteFilePath : Attribute
        {
            public readonly string Text;

            public RemoteFilePath(string text)
            {
                Text = text;
            }
        }
    }
}