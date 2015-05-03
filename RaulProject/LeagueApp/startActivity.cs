using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace LeagueApp
{
	[Activity (Label = "LeagueApp", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class startActivity : Activity
	{
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
				string Region = "";
				string SummonerName = editText1.Text;
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
			};
		}
	}
}


