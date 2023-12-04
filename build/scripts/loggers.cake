
///////////////////////////////////////////////////////////////////////////////
// ATTACHMENTS
///////////////////////////////////////////////////////////////////////////////

public void CombineAttachments(IList<SlackChatMessageAttachment> lstOutput, IList<SlackChatMessageAttachment> lstInput)
{
	foreach(SlackChatMessageAttachment itmAttachment in lstInput)
	{
		if (lstOutput.Count < 10)
		{
			if ((lstOutput.Count > 0) && (lstOutput[lstOutput.Count - 1].Pretext == itmAttachment.Pretext))
			{
				itmAttachment.Pretext = "";
			}

			lstOutput.Add(itmAttachment);
		}
	}
}


public string GetPrefix(string name)
{
	string prefix = "";

	foreach(string projectName in projectNames)
	{
		int start = name.IndexOf(projectName);

		if (start > 0)
		{
			prefix = name.Substring(0, start + projectName.Length + 1);
		}
	}

	return prefix;
}



///////////////////////////////////////////////////////////////////////////////
// MS BUILD
///////////////////////////////////////////////////////////////////////////////

public IList<SlackChatMessageAttachment> GetMsBuildAttachments(string path, Exception exception)
{
	// Get Errors
	IList<SlackChatMessageAttachment> attachments = new List<SlackChatMessageAttachment>();

	string[] lines = FileReadLines(path);
	IList<string> errors = new List<string>();

	foreach(string line in lines)
	{
		bool found = false;

		foreach(string name in projectNames)
		{
			if (line.StartsWith("  " + name + " -> "))
			{
				found = true;
			}
		}		

		if (!found)
		{
			errors.Add(line);
		}
	}



	// Get Attachments
	if (errors.Count > 0)
	{
		foreach(string error in errors)
		{
			int start = error.LastIndexOf("[");

			string name = "";
			string file = "";
			string source = "";
			string location = "";

			if (start > 0)
			{
				// Get Name
				name = error.Substring(start + 1, error.Length - (start + 2));
				string prefix = GetPrefix(name);

				if (!String.IsNullOrEmpty(prefix))
				{
					name = name.Replace(prefix, "");
				}

				name = name.Replace(@"\", "/").Replace(".csproj", "");

				source = error.Substring(0, start);
				int seperator = source.IndexOf(":");

				if (seperator > 0)
				{
					// Location
					file = source.Substring(0, seperator);
					start = file.LastIndexOf("(");
					
					if (start > 0)
					{
						location = file.Substring(start, file.Length - start);
						location = location.Replace(",", ", ");

						file = file.Substring(0, start);
					}



					// Source
					source = source.Substring(seperator, source.Length - seperator);

					if (source.StartsWith(": "))
					{
						source = source.Substring(2, source.Length - 2);
					}
				}
			}

			// Add Attachment
			attachments.Add(new SlackChatMessageAttachment()
			{
				Pretext = name.Trim() + "/" + file.Trim(),
				Title = source.Trim(),
				Text = location.Trim(),
				Color = "danger"
			});
		}
	}
	else
	{
		// General Error
		attachments.Add(new SlackChatMessageAttachment()
		{
			Pretext = "An exception occured while trying to run MSBuild",
			Text = exception.Message,
			Color = "danger"
		});
	}

	return attachments;
}