using Microsoft.Xna.Framework.Audio;

namespace Collison_Tiles
{
  internal class Sound
  {
    private SoundEffectInstance soundInstance;

    public Sound(SoundEffect sound)
    {
      this.soundInstance = sound.CreateInstance();
    }

    public SoundEffectInstance SOUND_INSTANCE
    {
      get { return soundInstance; }
    }
  }
}
