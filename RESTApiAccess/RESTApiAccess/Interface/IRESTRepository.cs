using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTApiAccess.Interface
{
    public interface IRESTRepository
    {
        /// <summary>
        /// Get call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        Task<T> GetApi<T>(string url, Dictionary<string, string> headers = null, string username = null, string password = null);

        /// <summary>
        /// Get call to api stream
        /// For large json responses
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        Task<T> GetApiStream<T>(string url, Dictionary<string, string> headers = null, string username = null, string password = null);

        /// <summary>
        /// Post call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        Task<T> PostApi<T, U>(string url, U data, Dictionary<string, string> headers = null, string username = null, string password = null);

        /// <summary>
        /// Post call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        Task<T> PostApi<T>(string url, Dictionary<string, string> headers = null, string username = null, string password = null);

        /// <summary>
        /// Put call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        Task<T> PutApi<T, U>(string url, U data, Dictionary<string, string> headers = null, string username = null, string password = null);

        /// <summary>
        /// Put call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        Task<T> PutApi<T>(string url, Dictionary<string, string> headers = null, string username = null, string password = null);

        /// <summary>
        /// Delete call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        Task<T> DeleteApi<T>(string url, Dictionary<string, string> headers = null, string username = null, string password = null);
    }
}
