using bNesis.Examples.DiscountCalculationApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace bNesis.Examples.DiscountCalculationApp.DAL
{
    public class Repository
    {
        private static Repository _instance;

        /// <summary>
        /// Instance of Repository
        /// </summary>
        public static Repository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Repository();

                return _instance;
            }

        }

        private Repository()
        {

        }

        /// <summary>
        /// Add new api response
        /// </summary>
        /// <param name="provider">Provider name</param>
        /// <param name="service">Service name</param>
        /// <param name="responseData"> XML data of response</param>
        public async Task AddApiResponse(string provider, string service, string responseData)
        {
            var apiResponse = new ApiResponse
            {
                Provider = provider,
                Service = service,
                Data = responseData
            };
            await AddApiResponse(apiResponse);
        }

        /// <summary>
        /// Add new api response
        /// </summary>
        /// <param name="apiResponse">Api response model</param>
        public async Task AddApiResponse(ApiResponse apiResponse)
        {
            using (var context = new BnContext())
            {
                apiResponse.Created = DateTime.Now;
                context.ApiResponses.Add(apiResponse);

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get api responses
        /// </summary>
        /// <returns>List of api responses</returns>
        public async Task<List<ApiResponse>> GetApiResponses()
        {
            using (var context = new BnContext())
            {
                return await context.ApiResponses.ToListAsync();
            }
        }

        /// <summary>
        /// Get api responses by service
        /// </summary>
        /// <param name="service"></param>
        /// <returns>List of api responses</returns>
        public async Task<List<ApiResponse>> GetApiResponsesByService(string service)
        {
            using (var context = new BnContext())
            {
                return await context.ApiResponses.Where(x => x.Service == service).ToListAsync();
            }
        }


        /// <summary>
        /// Check access to database
        /// </summary>
        /// <returns>Return true if database is avaible.</returns>
        public bool IsAvaible()
        {
            try
            {
                var bnContext = new BnContext();

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        //todo you can expand this repository with yourself methods
    }
}