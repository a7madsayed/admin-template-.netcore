namespace CompanyName.ProductName.Admin.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MissingConfigurationKeyException : Exception
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingConfigurationKeyException"/> class.
        /// </summary>
        /// <param name="configurationKey">The key of the missing configuration.</param>
        public MissingConfigurationKeyException(string configurationKey)
        {
            _message = $"A configuration key '{configurationKey}' doesn't exist.";
            ConfigurationKey = configurationKey;
        }

        public MissingConfigurationKeyException()
        {
        }

        public MissingConfigurationKeyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets a user-friendly message describe the missing configuration
        /// </summary>
        public override string Message => _message;

        /// <summary>
        /// Gets configuration key name
        /// </summary>
        public string ConfigurationKey { get; }

        /// <inheritdoc/>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ConfigurationKey", ConfigurationKey);
        }
    }
}
