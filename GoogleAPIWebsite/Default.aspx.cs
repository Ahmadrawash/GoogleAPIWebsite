/*
 * author: Dr. Ahmad Rawashdeh
 * course: Web Technology BIT 386
  */

using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleAPIWebsite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            


            String key = "";
            String query = ""; 
            String cx = "";
            String results = "";

           
            //get the text of the textboxes (query, cx, and key)
            query = queryTextBox.Text.Trim();
            cx = cxTextBox.Text.Trim();
            key = keyTextBox.Text.Trim();

          
            //error checking
            if (query == null || query.Equals(""))
            {
                outputLabel.Text = "error: query is empty";
                return;
            }
            if (key == null || key.Equals(""))
            {
                outputLabel.Text = "error: search key is empty or not found. you should create a txt file \"key.txt\" in the debug folder of your project";
                return;
            }
            if (cx == null || cx.Equals(""))
            {
                outputLabel.Text = "error: search program id wasn't found. you should create a text file \"searchProgram.txt\" in the debug folder of your project";
                return;
            }

            
            //start using the Goolge API search
            try
            {
                //create the request object
                //GET https://www.googleapis.com/customsearch/v1?key=INSERT_YOUR_API_KEY&cx=017576662512468239146:omuauf_lfve&q=lectures
                HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + key + "&cx=" + cx + "&q=" + query);
                hwr.Method = "GET";

                //send the request and get the response (result) object. This is where the Google API Web service is used
                HttpWebResponse wr = (HttpWebResponse)hwr.GetResponse();
                Stream stre = wr.GetResponseStream();
                StreamReader responseSr = new StreamReader(stre);
                results =  responseSr.ReadToEnd();
                
                //create a file of type json which has as a content the response returned from google search web service above
                StreamWriter sw = new StreamWriter(Server.MapPath("result_" + query + ".json"));
                sw.Write(results);
                sw.Close();

                //display the response of the google web service as the text of the label
                outputLabel.Text = results;

                //send the json file to client for download
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/json";
                Response.AddHeader("content-disposition", "attachment; filename=result_" + query + ".json");
                Response.WriteFile(Server.MapPath("~/result_" + query + ".json"));
                Response.Flush();
                Response.End();                          
                return;
            }

            catch (Exception exc)
            {
                outputLabel.Text = "Exeption: " + exc.Message + "\n" + exc.StackTrace;
            }

        }

    }
}