using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ScreenRuler.Configuration
{
    /// <summary>
    /// Models a serializable collection of MonitorDpiConfiguration.
    /// </summary>
    [Serializable]
    public class MonitorDpiConfigurationCollection : ICollection<MonitorDpiConfiguration>
    {
        [XmlIgnore]
        private Dictionary<string, MonitorDpiConfiguration> configurations = new Dictionary<string, MonitorDpiConfiguration>();

        [XmlElement]
        public MonitorDpiConfiguration[] ConfigurationList
        {
            get => configurations.Values.ToArray();
            set
            {
                configurations = value.ToDictionary(v => v.Id);
            }
        }

        public MonitorDpiConfiguration this[string key]
        {
            get => configurations[key];
            set => configurations[key] = value;
        }

        public int Count => configurations.Count;

        public bool IsReadOnly => false;

        public void Add(MonitorDpiConfiguration item) => configurations.Add(item.Id, item);

        public void Clear() => configurations.Clear();

        public bool Contains(MonitorDpiConfiguration item) => configurations.ContainsValue(item);

        public bool ContainsKey(string key) => configurations.ContainsKey(key);

        public void CopyTo(MonitorDpiConfiguration[] array, int arrayIndex)
        {
            configurations.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<MonitorDpiConfiguration> GetEnumerator() => configurations.Values.GetEnumerator();

        public bool Remove(MonitorDpiConfiguration item) => configurations.Remove(item.Id);

        IEnumerator IEnumerable.GetEnumerator() => configurations.Values.GetEnumerator();
    }
}
