using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Configuration
{
	public class TemplatesCollection: ConfigurationElementCollection
	{
		#region Constructor
		public TemplatesCollection()
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
				return "template";
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
		public Template this[int index]
		{
			get
			{
				return (Template)base.BaseGet(index);
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

		public Template this[string name]
		{
			get
			{
				return (Template)base.BaseGet(name);
			}
		}
		#endregion

		#region Methods
		public void Add(Template item)
		{
			base.BaseAdd(item);
		}

		public void Remove(Template item)
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
			return new Template();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as Template).Name;
		}
		#endregion
	}
}
