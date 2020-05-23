using System;

namespace StardewModdingAPI.Web.Framework.Caching
{
    /// <summary>A cache entry.</summary>
    /// <typeparam name="T">The cached value type.</typeparam>
    internal class Cached<T>
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The cached data.</summary>
        public T Data { get; set; }

        /// <summary>When the data was last updated.</summary>
        public DateTimeOffset LastUpdated { get; set; }

        /// <summary>When the data was last requested through the mod API.</summary>
        public DateTimeOffset LastRequested { get; set; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an empty instance.</summary>
        public Cached() { }

        /// <summary>Construct an instance.</summary>
        /// <param name="data">The cached data.</param>
        public Cached(T data)
        {
            this.Data = data;
            this.LastUpdated = DateTimeOffset.UtcNow;
            this.LastRequested = DateTimeOffset.UtcNow;
        }
    }
}
