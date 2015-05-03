using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Newtonsoft.Json;



namespace LeagueApp
{
	[Activity (Label = "LeagueApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class startActivity : Activity
	{
		string Region;
		string SummonerName;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		
			// set the layout for this activity
			SetContentView (Resource.Layout.startActivity);

			// establish the elements in the layout
			Button proceedButton = FindViewById<Button> (Resource.Id.proceedButton);
			EditText editText1 = FindViewById<EditText> (Resource.Id.editText1);
			TextView textView1 = FindViewById<TextView> (Resource.Id.textView1);
			TextView textView2 = FindViewById<TextView> (Resource.Id.textView2);
			TextView textView3 = FindViewById<TextView> (Resource.Id.textView3);
			CheckBox checkBox1 = FindViewById<CheckBox> (Resource.Id.rememberMe);

			
			proceedButton.Click += delegate {
				// check if everything's filled
				Region = "";
				SummonerName = editText1.Text;

				bool rememberMe = checkBox1.Checked;

				RadioGroup radioGroup1 = FindViewById<RadioGroup> (Resource.Id.radioGroup1);

				RadioButton radioButton1 = FindViewById<RadioButton> (Resource.Id.radioButton1);
				RadioButton radioButton2 = FindViewById<RadioButton> (Resource.Id.radioButton2);
				RadioButton radioButton3 = FindViewById<RadioButton> (Resource.Id.radioButton3);	


				List<RadioButton>  radioButtons = new List<RadioButton>();

				radioButtons.Add(radioButton1);
				radioButtons.Add(radioButton2);
				radioButtons.Add(radioButton3);
			
			
				// Run a loop to check if and which RadioButton is selected;
				for (int checkedID = 0; checkedID <= radioButtons.Count - 1; checkedID++) {
					if (radioButtons[checkedID].Checked){
						Region = radioButtons[checkedID].Text;
					};
				};


				// Check if the summoner name and region is valid.
				if (SummonerName.Length <= 1) 
				{
					Toast.MakeText(this, "You didn't fill out a valid summoner name!", ToastLength.Short).Show();
					return;
				}
				else if (Region.Length == 0)
				{
					Toast.MakeText(this, "You didn't select a region!", ToastLength.Short).Show();
					return;
				};

				CheckSummonerName(SummonerName);
			};
		}

		void CheckSummonerName(string SummonerName)
		{
			string url = FormatURL (SummonerName);
			//Create a new WebRequest
			System.Net.WebRequest request = System.Net.WebRequest.Create(url);
			Toast.MakeText(this, "We have succesfully sent a request to the server!", ToastLength.Short).Show();
		}

		string FormatURL(string SummonerName){
			// we need the Region the player is in, and the player name in a variable here.
			string api_key = "6b7a1e1f-4f2b-4d5f-ad2e-dfc5f9fbdd54"
			string url = String.Format ("https://{0}.api.pvp.net/api/lol/{1}/v1.4/summoner/by-name/{2}?api_key={3}", Region, Region, SummonerName, api_key);

			return url;
							
		}
	}
}


