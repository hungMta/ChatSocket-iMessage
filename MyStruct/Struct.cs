using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;

namespace MyStruct
{
    [Serializable()]
    public class Struct: ISerializable
    {
        private string textChat;
        private Font font;
        private Color color;


        public Struct()
        {
            this.textChat = null;
            this.font = null;
            this.color = Color.Black;
        }

        public Struct(string text, Font font , Color color)
        {
            this.textChat = text;
            this.font = font;
            this.color = color;

        }

        public string TextChat { get => textChat; set => textChat = value; }
        public Font Font { get => font; set => font = value; }
        public Color Color { get => color; set => color = value; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("text",this.textChat);
            info.AddValue("font", this.font);
            info.AddValue("color", this.color);
        }

        public Struct(SerializationInfo info, StreamingContext context)
        {
            this.textChat = (string)info.GetValue("text",typeof(string));
            this.font = (Font)info.GetValue("font", typeof(Font));
            this.color = (Color)info.GetValue("color", typeof(Color));
        }
    }
}
