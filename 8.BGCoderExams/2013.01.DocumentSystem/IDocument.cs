using System;
namespace DocumentSystem
{
    interface IDocument
    {
        string Content { get; }
        void LoadProperty(string key, string value);
        string Name { get; }
        void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output);
        string ToString();
    }
}
