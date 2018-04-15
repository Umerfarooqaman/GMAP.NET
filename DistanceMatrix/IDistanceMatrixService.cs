using System.Threading.Tasks;
using GMAP.NET.DistanceMatrix.Utils;

namespace GMAP.NET.DistanceMatrix
{
    public interface IDistanceMatrixService
    {
        /// <summary>
        /// Gets or sets the authintication key provided by google .
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Sends the distance matrix request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns ></returns>
        DistanceMatrixResult SendDistanceMatrixRequest(DistanceMatrixRequest request);
        /// <summary>
        /// Sends the distance matrix request asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<DistanceMatrixResult> SendDistanceMatrixRequestAsync(DistanceMatrixRequest request);
    }
}