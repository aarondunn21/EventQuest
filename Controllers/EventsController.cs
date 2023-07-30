using System;
using System.Net.Http;
using System.Threading.Tasks;
using EventQuest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class EventsController : Controller
{
    private readonly string apiKey = "qOGkxRUqBIhxhbcLDxtysEz4XrspA9bp";
    private readonly string apiUrl = "https://app.ticketmaster.com/discovery/v2/events.json";

    public async Task<ActionResult> Index()
    {
        try
        {
            // Set up the HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                // Set up the query parameters
                string countryCode = "US"; // Change to your desired country code
                string city = "Atlanta"; // Change to your desired city

                // Build the API request URL with query parameters and API key
                string requestUrl = $"{apiUrl}?apikey={apiKey}&countryCode={countryCode}&city={city}";

                // Send the HTTP request and get the response
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a class representing the Ticketmaster API response
                    TicketmasterResponse ticketmasterResponse = JsonConvert.DeserializeObject<TicketmasterResponse>(jsonResponse);

                    // Pass the events data to the view
                    return View(ticketmasterResponse._embedded.events);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Failed to fetch events. Status Code: {response.StatusCode}";
                }
            }
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Error: {ex.Message}";
        }

        // Return an empty view if an error occurred
        return View();
    }
}

