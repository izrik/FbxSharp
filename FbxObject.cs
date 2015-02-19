using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxObject : Emitter
    {
        protected readonly List<Property> _properties = new List<Property>();

        //Searches a property by name.
        public Property FindProperty(string name, bool caseSensitive=true)
        {
            return _properties.Find(p => 
                string.Compare(p.Name, name, ignoreCase: !caseSensitive) == 0
            );
        }

        //Searches a property by name and data type.
        public Property FindProperty(string name, Type type, bool caseSensitive=true)
        {
            return _properties.Find(p => {
                if (p.PropertyDataType != type) return false;

                return string.Compare(p.Name, name, ignoreCase: !caseSensitive) == 0;
            });
        }
        public PropertyT<T> FindProperty<T>(string name, bool caseSensitive=true)
        {
            return (PropertyT<T>)_properties.Find(p => {
                if (!(p is PropertyT<T>)) return false;

                return string.Compare(p.Name, name, ignoreCase: !caseSensitive) == 0;
            });
        }

        public PropertyT<T> CreateProperty<T>(string name)
        {
            return new PropertyT<T>(name);
        }
        public Property CreateProperty(string name, Type type)
        {
            var concreteType = typeof(PropertyT<>).MakeGenericType(type);
            var prop = (Property)Activator.CreateInstance(concreteType, (object)name);
            return prop;
        }
//        public FbxPropertyT<T> FindOrCreateProperty<T>(string name, bool caseSensitive=true)
//        {
//            var prop = FindProperty<T>(name, caseSensitive);
//            if (prop == null)
//            {
//                prop = CreateProperty<T>(name);
//                _properties.Add(prop);
//            }
//            return prop;
//        }


        public string Name { get; set; }

        //Returns the name of the object without the namespace qualifier.
        public string NameWithoutNameSpacePrefix { get { throw new NotImplementedException(); } }

        //Returns the name of the object with the namespace qualifier.
        public string NameWithNameSpacePrefix { get { throw new NotImplementedException(); } }

        public string InitialName { get; set; }

        public string NameSpace { get; set; }

        //Returns an array of all the namespaces for this object.
        public string[] GetNameSpaceArray(char identifier)
        {
            throw new NotImplementedException();
        }

        //Returns only the name (no namespace or prefix) of the object.
        public string NameOnly { get { throw new NotImplementedException(); } }

        //Returns the namespace qualifier.
        public string NameSpacePrefix { get { throw new NotImplementedException(); } }

        //Returns the unique ID of this object.
        public ulong UniqueId { get; set; } //protected set; }

        //Removes the prefix of pName.
        static string RemovePrefix(string pName)
        {
            throw new NotImplementedException();
        }

        //Strips the prefix of lName.
        static string StripPrefix(string lName)
        {
            throw new NotImplementedException();
        }

    }
}

