using System.ComponentModel;

  public class SantasApprovedLists
  {
    public List<string> NiceMusicGenre = new List<string>();

    public void AddGenre(string genre)
    {
      NiceMusicGenre.Add("Punk");
      NiceMusicGenre.Add("Synthpop");
      NiceMusicGenre.Add("Reggae");
      NiceMusicGenre.Add("Salsa");
      NiceMusicGenre.Add("Opera");
      NiceMusicGenre.Add("K-pop");
    }

    public List<string> NiceCarModel = new List<string>();

    public void AddCar(string model)
    {
      NiceCarModel.Add("Tesla");
      NiceCarModel.Add("Mercedes-Benz E-Class");
      NiceCarModel.Add("Nissan leaf");
      NiceCarModel.Add("Kia Optima");
      NiceCarModel.Add("Ford Focus");
      NiceCarModel.Add("Chevrolet Malibu");
      NiceCarModel.Add("Hyundai Veloster");
    }
  }