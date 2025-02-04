﻿using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WpfOpenTK
{
	public class ShaderProgram
	{
		#region Fields (1)

		private string programInfoLog;
		//private int ShaderProgramHandle;

		#endregion Fields

		#region Properties (2)

		public string ProgramInfoLog
		{
			get
			{
				return programInfoLog;
			}
			set
			{
				programInfoLog = value;
			}
		}

		public int ShaderProgramHandle
		{
			get;
			set;
		}

		#endregion Properties

		#region Methods (1)

		// Public Methods (1) 

		public ShaderProgram()
		{
			ShaderProgramHandle = GL.CreateProgram();
		}

		public void build( int shaderHandle )
		{
			// GL.AttachShader( ShaderProgramHandle, shaderHandle );
			//this.addShader( int shaderHandle);

			GL.LinkProgram( ShaderProgramHandle );

			GL.GetProgramInfoLog( ShaderProgramHandle, out programInfoLog );
		}

		public void addShader( int shaderHandle )
		{
			GL.AttachShader( ShaderProgramHandle, shaderHandle );
		}

		public void Use()
		{
			GL.UseProgram( ShaderProgramHandle );
		}

		public void Unuse()
		{
			GL.UseProgram( 0 );
		}

		public void SetUniform1( string uniformVariable, int value )
		{
			var uniformLocation = GL.GetUniformLocation( ShaderProgramHandle, uniformVariable );
			GL.Uniform1( uniformLocation, value );
		}

		public void SetUniform1( string uniformVariable, float value )
		{
			int uniformLocation = GL.GetUniformLocation( ShaderProgramHandle, uniformVariable );
			GL.Uniform1( uniformLocation, value );
		}

		public void SetUniform3( string uniformVariable, Vector3 value )
		{
			int uniformLocation = GL.GetUniformLocation( ShaderProgramHandle, uniformVariable );
			GL.Uniform3( uniformLocation, value );
		}

		#endregion Methods
	}
}