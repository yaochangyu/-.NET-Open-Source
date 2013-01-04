using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;

namespace Tako.GlobalHotKey
{
    [Serializable]
    public class HotKey
    {
        private Key _key;
        private ModifierKeys _modifierKeys;

        public Key Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public ModifierKeys ModifierKeys
        {
            get { return _modifierKeys; }
            set { _modifierKeys = value; }
        }

        public HotKey(ModifierKeys modifiers, Key key)
        {
            this.Key = key;
            this.ModifierKeys = modifiers;
        }

        public override bool Equals(object obj)
        {
            var targetArray = getObjectByte(this);
            var expectedArray = getObjectByte(obj);
            var equals = expectedArray.SequenceEqual(targetArray);
            return equals;
        }

        private static byte[] getObjectByte(object model)
        {
            if (model == null)
            {
                return null;
            }
            using (MemoryStream memory = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memory, model);
                var array = memory.ToArray();
                return array;
            }
        }

        public static bool operator ==(HotKey left, HotKey right)
        {
            var leftArray = getObjectByte(left);
            if (leftArray == null)
            {
                return true;
            }

            var reightArray = getObjectByte(right);
            if (reightArray == null)
            {
                return false;
            }

            if (leftArray == null && reightArray == null)
            {
                return false;
            }
            var equals = leftArray.SequenceEqual(reightArray);
            return equals;
        }

        public static bool operator !=(HotKey left, HotKey right)
        {
            if (left == right)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode() ^ this.ModifierKeys.GetHashCode();
        }

        public override string ToString()
        {
            var mk = (int)ModifierKeys;
            var modifierKey = ModifierKeys.ToString().Replace(" ", "");
            if (modifierKey.IndexOf(",") > 0)
            {
                var split = modifierKey.Split(',');
                if (split != null && split.Length > 0)
                {
                    modifierKey = split[0] + "+" + split[1];
                }
            }
            var hotKey = string.Format("{0}+{1}", modifierKey, this.Key.ToString());

            return hotKey;
        }
    }
}