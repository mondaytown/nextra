using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.object.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Clone an object to a copy of the same type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="original">The original object to clone.</param>
        /// <returns>The clone result.</returns>
        public static T Clone<T>(this object original)
        {
            if (original == null)
                return default(T);

            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();

            formatter.Serialize(stream, original);
            stream.Seek(0, SeekOrigin.Begin);

            var result = (T) formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}