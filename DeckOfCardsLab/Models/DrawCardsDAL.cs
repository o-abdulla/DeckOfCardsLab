using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsLab.Models
{
    public class DrawCardsDAL
    {
        public static DrawCardsModel Draw5Cards() //Adjust here
        {
            //Adjust
            //Setup
            string deckID = Secret.deckID;
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count=5";

            //Request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Converting to json
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            //Adjust
            //Convert to c#
            //Install Newtonsoft.json
            DrawCardsModel result = JsonConvert.DeserializeObject<DrawCardsModel>(json);
            return result;
        }

        public static DrawCardsModel Reshuffle() //Adjust here
        {
            //Adjust
            //Setup
            string apiKey = Secret.deckID;
            string url = $"https://deckofcardsapi.com/api/deck/{apiKey}/shuffle/";

            //Request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Converting to json
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            //Adjust
            //Convert to c#
            //Install Newtonsoft.json
            DrawCardsModel result = JsonConvert.DeserializeObject<DrawCardsModel>(json);
            return result;
        }

    }
}

