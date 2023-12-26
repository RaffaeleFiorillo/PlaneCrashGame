using System;
using System.Collections.Generic;

public class Episode
{
    #region Proprerties

    /// <summary>
    /// Name of the Episode
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The type of button setup used by this Episode to control the game.
    /// </summary>
    private string InputSetupType { get; set; }

    /// <summary>
    /// The names of the audios to play in every Episode
    /// </summary>
    private List<string> AudioNames { get; set; }

    /// <summary>
    /// The audio clips to play in this Episode.
    /// </summary>
    private List<AudioClip> AudioClips { get; set; }

    private int AudioOrder = 0;

    /// <summary>
    /// Object responsible for managing the Input from the user with it's own kind of button setup.
    /// </summary>
    private ButtonInputControllerSetup InputSetup { get; set; }

    /// <summary>
    /// Data necessary to procede to next Episodes. {(str)*episode-name*: (str)*button-linked-to-episode*;}
    /// </summary>
    private Dictionary<string, string> NextEpisodes { get; set; }

    #endregion Proprerties

    /// <summary>
    /// Creates an episode for the plane game based on a file with all the information about it.
    /// </summary>
    /// <param name="configFileDir">Directory of the file with all the information about the episode</param>
    public Episode(string configFileDir)
	{
        InputSetupType = "two-buttons";
        LoadEpisodeFromFile(configFileDir);

        // Sets Up the object responsible for managing the Input from the user based on a certain Button setup.
        InputSetup = ButtonInputControllerSetup(InputSetupType);
	}


    /// <summary>
    /// Loads all the data from the file regarding this Episode.
    /// </summary>
    /// <param name="configFileDir">Directory of the file with all the information about the episode</param>
    /// <returns>true: The data was loaded succesfully | false: There was an error loading this Episode.</returns>
    private bool LoadEpisodeFromFile(string fileDir) 
    {
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(fileDir);

            // Iterate through each line and process the data
            foreach (string line in lines)
            {
                // Split the line into key and value (assuming a simple key-value format)
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    // Assign the value to the appropriate property based on the key
                    switch (key)
                    {
                        case "Name":
                            Name = value;
                            break;
                        case "InputSetupType":
                            InputSetupType = value;
                            break;
                        case "AudioNames":
                            // Assuming AudioNames is a comma-separated list
                            AudioNames = new List<string>(value.Split(','));
                            LoadAudios();
                            break;
                        case "NextEpisodes":
                            NextEpisodes = new Dictionary<string, string>();
                            // Assuming the format is like: key1:value1;key2:value2;...
                            string[] episodePairs = value.Split(';');
                            foreach (string pair in episodePairs)
                            {
                                string[] keyValue = pair.Split('-');
                                if (keyValue.Length == 2)
                                {
                                    string episodeName = keyValue[0].Trim();
                                    string episodeDataFileDir = keyValue[1].Trim();
                                    NextEpisodes.Add(episodeName, episodeDataFileDir);
                                }
                            }
                            break;
                        default:
                            // Handle unknown keys or skip them
                            break;
                    }
                }
            }

            return true; // Data loaded successfully
        }
        catch (Exception ex)
        {
            return false; // Error loading episode
        }
    }


    /// <summary>
    /// Loads all the audios associated to the Episodes.
    /// </summary>
    /// <returns></returns>
    private bool LoadAudios()
    {
        bool errorLoading = false;
        try
        {
            // Load AudioClip based on the file name
            AudioClip audioClip = Resources.Load<AudioClip>(audioFileName.Trim());
            if (audioClip != null)
            {
                AudioClips.Add(audioClip);
            }
            else
            {
                Debug.LogError($"Audio file not found: {audioFileName}");
                errorLoading = true;
            }
        }
        catch(Exception ex)
        {
            return false;
        }
        foreach (string audioFileName in AudioNames)
        {

        }

        return !errorLoading;
    }


    /// <summary>
    /// Play the audio related to this Episode.
    /// </summary>
    public void PlayAudio()
    {
        if (AudioClips != null && AudioClips.Count > 0)
        {
            // Play the audio by order audio clip from the list

            // Set the AudioClip to the AudioSource and play it
            audioSource.clip = AudioClips[AudioOrder];
            audioSource.Play();

            AudioOrder++;
        }
        else
        {
            Debug.LogWarning("No audio clips available for this episode.");
        }
    }


    /// <summary>
    /// Manages the user input until the point where the user should go to the next episode.
    /// </summary>
    /// <returns>The Episode the user should be in</returns>
    public Episode ManageInput()
    {
        InputSetup.ManageInput();

        if (InputSetup.ConditionForNextEpisodeIsSatisfied)
            return GetNextEpisode(InputSetup.NextEpisodeButton);
        return this;
    }


    /// <summary>
    /// Returns the Episode
    /// </summary>
    /// <returns></returns>
    public Episode GetNextEpisode(string episodeButton)
    {
        return NextEpisodes[episodeButton];
    }
}
