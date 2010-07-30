﻿using System;
using OpenTK.Graphics.OpenGL;

namespace WpfOpenTK.OpenGL
{
	public class Texture3D
	{
		int textureHandle = 2;

		public Texture3D( int width, int height, int depth )
		{
			GL.Enable( EnableCap.Texture3DExt );

			GL.GenTextures( 1, out textureHandle );
			GL.ActiveTexture( TextureUnit.Texture2 );
			GL.BindTexture( TextureTarget.Texture3D, textureHandle );

			GL.TexImage3D( TextureTarget.Texture3D, 0, PixelInternalFormat.Four, width, height, depth, 0, PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero );

			GL.TexParameter( TextureTarget.Texture3D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Linear );
			GL.TexParameter( TextureTarget.Texture3D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Linear );
			GL.TexParameter( TextureTarget.Texture3D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Clamp );
			GL.TexParameter( TextureTarget.Texture3D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Clamp );
			GL.TexParameter( TextureTarget.Texture3D, TextureParameterName.TextureWrapR, (int) TextureWrapMode.Clamp );

			////GL.TexParameterI(TextureTarget.Texture3D,TextureParameterName.TextureWrapR,

			GL.BindTexture( TextureTarget.Texture3D, 0 );

			/*
			GL.GenTextures( 1, out textureHandle );
			GL.ActiveTexture( TextureUnit.Texture2 );
			GL.BindTexture( TextureTarget.Texture2D, textureHandle );
			GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Nearest );
			GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Nearest );
			GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Clamp );
			GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Clamp );
			GL.TexImage2D( TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, width, height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero );
			// test for GL Error here (might be unsupported format)

			GL.BindTexture( TextureTarget.Texture2D, 0 ); // prevent feedback, reading and writing to the same image is a bad idea
			*/
		}

		public void Load( int width, int height, int depth, uint[, ,] textureData )
		{
			//GL.ActiveTexture( TextureUnit.Texture2 );
			GL.BindTexture( TextureTarget.Texture3D, textureHandle );
			GL.TexImage3D( TextureTarget.Texture3D, 0, PixelInternalFormat.Four, width, height, depth, 0, PixelFormat.Bgra, PixelType.UnsignedByte, textureData );
			GL.BindTexture( TextureTarget.Texture3D, 0 );
		}

		public void Bind()
		{
			//GL.ActiveTexture( TextureUnit.Texture2 );
			GL.BindTexture( TextureTarget.Texture3D, textureHandle );
			GL.Enable( EnableCap.Texture3DExt );
		}

		public void Unbind()
		{
			//GL.ActiveTexture( TextureUnit.Texture2 );
			GL.BindTexture( TextureTarget.Texture3D, 0 );
			GL.Disable( EnableCap.Texture3DExt );
		}
	}
}