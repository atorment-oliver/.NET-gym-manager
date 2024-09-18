using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Configuration
{
	public class ParamsCollection: ConfigurationElementCollection
	{
		#region Constructor
        public ParamsCollection()
		{
		}
		#endregion

		#region Properties
		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.BasicMap;
			}
		}
		protected override string ElementName
		{
			get
			{
				return "param";
			}
		}

		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return new ConfigurationPropertyCollection();
			}
		}
		#endregion

		#region Indexers
        public Param this[int index]
		{
			get
			{
                return (Param)base.BaseGet(index);
			}
			set
			{
				if (base.BaseGet(index) != null)
				{
					base.BaseRemoveAt(index);
				}
				base.BaseAdd(index, value);
			}
		}

		public Param this[string name]
		{
			get
			{
                return (Param)base.BaseGet(name);
			}
		}
		#endregion

		#region Methods
        public void Add(Param item)
		{
			base.BaseAdd(item);
		}

        public void Remove(Param item)
		{
			base.BaseRemove(item);
		}

		public void RemoveAt(int index)
		{
			base.BaseRemoveAt(index);
		}
		#endregion

		#region Overrides
		protected override ConfigurationElement CreateNewElement()
		{
            return new Param();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
            return (element as Param).Name;
		}
		#endregion
	}
}
