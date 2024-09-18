using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SystemConfig
{
	public class RevisionCaja: ConfigurationElement
	{
		#region Constructors
        static RevisionCaja()
		{
            s_propId = new ConfigurationProperty(
                "id",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
                );
            s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propId);
		}
		#endregion

		#region Fields
        private static ConfigurationPropertyCollection s_properties;
        private static ConfigurationProperty s_propId;
		#endregion

		#region Properties
        public string Id
        {
            get { return (string)base[s_propId]; }
            set { base[s_propId] = value; }
        }
        
		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return s_properties;
			}
		}
		#endregion
	}
}
