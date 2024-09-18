using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Configuration
{
	public class MailManagementSection: ConfigurationSection
	{
		#region Constructors
		static MailManagementSection()
		{
            s_propSendCopy = new ConfigurationProperty(
                "sendcopy",
				typeof(bool),
				null,
				ConfigurationPropertyOptions.IsRequired
				);

            s_propSendHTML = new ConfigurationProperty(
                "sendHTML",
                typeof(bool),
                null,
                ConfigurationPropertyOptions.IsRequired
                );

            s_propTemplates = new ConfigurationProperty(
                "templates",
                typeof(TemplatesCollection),
                null,
                ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection
                );

            s_propParams = new ConfigurationProperty(
                "params",
                typeof(ParamsCollection),
                null,
                ConfigurationPropertyOptions.None
                );

			s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propSendCopy);
            s_properties.Add(s_propSendHTML);
            s_properties.Add(s_propTemplates);
            s_properties.Add(s_propParams);
		}
		#endregion

		#region Fields
		private static ConfigurationPropertyCollection s_properties;
        private static ConfigurationProperty s_propSendCopy;
        private static ConfigurationProperty s_propSendHTML;
        private static ConfigurationProperty s_propTemplates;
        private static ConfigurationProperty s_propParams;
		#endregion

		#region Properties
		public bool SendCopy
		{
            get { return (bool)base[s_propSendCopy]; }
            set { base[s_propSendCopy] = value; }
		}

        public bool SendHTML
        {
            get { return (bool)base[s_propSendHTML]; }
            set { base[s_propSendHTML] = value; }
        }

        public TemplatesCollection Templates
        {
            get { return (TemplatesCollection)base[s_propTemplates]; }
        }
        
        public ParamsCollection Params
        {
            get { return (ParamsCollection)base[s_propParams]; }
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