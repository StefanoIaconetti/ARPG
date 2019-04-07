using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saving {

	public static void SavePlayerInfo (Player player, EquipmentManager equipManag){
		BinaryFormatter formatter = new BinaryFormatter ();
		string path = Application.persistentDataPath + "/player.save";
		FileStream stream = new FileStream (path, FileMode.Create);


		SavingData data = new SavingData (player, equipManag);
		formatter.Serialize (stream, data);	
		stream.Close ();

	}

	public static SavingData LoadPlayer(){
		string path = Application.persistentDataPath + "/player.save";


		if (File.Exists (path)) {
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream stream = new FileStream (path, FileMode.Open);

			SavingData data = formatter.Deserialize (stream) as SavingData;
			stream.Close ();

			return data;
		} else {
			Debug.Log ("Not working");
			return null;
		}

}
}