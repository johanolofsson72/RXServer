#region -- Copyright © 2007 Cambia Research.  All rights reserved. --
// ----------------------------------------------------------------------------------
// Author: Steve Lautenschlager, steve@cambiaresearch.com
// Date: Jan 2007
// You may use this code in your personal or commercial projects as long as this 
// header remains intact.  Copyright and all rights remain with the author.
// ----------------------------------------------------------------------------------
#endregion
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace Cambia.Web.CoreLib
{
	/// <summary>
	/// PathHelper retrieves and converts URLs and physical file paths in ASP.NET
	/// applications.
	/// 
	/// Definitions:
	/// -------------
	/// Absolute URL:     http://www.cambiaresearch.com/c4/Default.aspx
	/// Virtual Path:     /c4/Default.aspx
	/// Physical Path:    C:\inetpub\wwwroot\cambia\c4\Default.aspx
	/// Application Path: Default.aspx (if a path is not one of the 3 classes above it is assumed 
	///                   to be application relative)
	/// 
	/// </summary>
	public class PathHelper
	{

		/// <summary>
		/// The virtual application path:
		/// "/myapp/"
		/// "/apps/myapp/"
		/// "/"
		/// </summary>
		public static string AppPath
		{
			get
			{
				// get the regular application path
				string path = HttpContext.Current.Request.ApplicationPath;

				// ensure a trailing slash...
				if (path == "")
					return "/";
				if (path[path.Length-1] != '/')
					path += "/";
				return path;
			}
		}
		public static string AppName
		{
			get
			{
				return GetImmediateFolderName(AppPath);
			}
		}


		#region -- Path Type Tests --
		public static PathType GetPathType(string path)
		{
			if (IsPhysicalPath(path))
				return PathType.Physical;
			else if (IsAbsolutePath(path))
				return PathType.Absolute;
			else if (IsVirtualPath(path))
				return PathType.Virtual;
			else if (IsApplicationPath(path))
				return PathType.AppRelative;
			else
				return PathType.None;
		}
		public static bool IsVirtualPath(string path)
		{
			if (path == "") 
				return false;

			// ----------------------------------------------------------------
			// simple test - if it starts with a / it's virtual
			// ----------------------------------------------------------------
			if (path[0] == '/')
				return true;

			// ----------------------------------------------------------------
			// strict test - requires leading /, but also requires the path to be 
			//               at or below our application path
			// ----------------------------------------------------------------
			// The AppPath property is the virtual path from the web root
			// to the ASP.NET application.  If the input path begins with
			// the AppPath then it is a virtual path _and_ it is a path
			// that exists in our application
//			if (path.ToLower().Trim().IndexOf(AppPath.ToLower().Trim()) == 0)
//				return true;
//			else
//				return false;

			return false;


		}
		public static bool IsPhysicalPath(string path)
		{
			// if the path begins with a drive letter it's a physical path
			if (path.IndexOf(@":\") >= 0)
				return true;

			// if it begins with "\\" its a physical network path
			if (path.IndexOf(@"\\") == 0)
				return true;

			return false;

		}
		public static bool IsAbsolutePath(string path)
		{			
			return path.IndexOf("://") >= 0;
		}
		public static bool IsApplicationPath(string path)
		{
			// must not be physical, absolute or virtual and 
			// cannot start with a "/"

			if (IsPhysicalPath(path))
				return false;
			if (IsAbsolutePath(path))
				return false;
			if (IsVirtualPath(path))
				return false;
			if (path.Length < 1)
				return true; // a blank path could be an app path when it's in the root directory
			if (path[0] == '/')
				return false;

			return true;

		}
		#endregion

		#region -- Conversions --
		public static string ToType(string path, PathType type)
		{
			switch (type)
			{
				case PathType.Absolute:
					if (IsAbsolutePath(path)) return path;
					if (IsVirtualPath(path)) return VirtualToAbsolute(path);
					if (IsApplicationPath(path)) return ApplicationToAbsolute(path);
					return PhysicalToAbsolute(path);
				case PathType.Physical:
					if (IsPhysicalPath(path)) return path;
					if (IsVirtualPath(path)) return VirtualToPhysical(path);
					if (IsApplicationPath(path)) return ApplicationToPhysical(path);
					return AbsoluteToPhysical(path);				
				case PathType.Virtual:
					if (IsVirtualPath(path)) return path;
					if (IsPhysicalPath(path)) return PhysicalToVirtual(path);
					if (IsApplicationPath(path)) return ApplicationToVirtual(path);
					return AbsoluteToVirtual(path);
				case PathType.AppRelative:
					if (IsApplicationPath(path)) return path;
					if (IsPhysicalPath(path)) return PhysicalToApplication(path);
					if (IsVirtualPath(path)) return VirtualToApplication(path);
					return AbsoluteToApplication(path);
			}
			return path;
		}

		public static string VirtualToPhysical(string virtualPath)
		{
			return HttpContext.Current.Request.MapPath(virtualPath).ToLower();
		}
		public static string VirtualToAbsolute(string virtualPath)
		{
			if (!IsVirtualPath(virtualPath))
				throw new Exception("Input path is not a virtual path");

			HttpRequest r = HttpContext.Current.Request;
			return r.Url.Scheme + "://" + r.Url.Authority + virtualPath;

		}

		public static string VirtualToApplication(string virtualPath)
		{
			if (!IsVirtualPath(virtualPath))
				throw new Exception("Input path is not a virtual path");


			if (AppPath.Length > virtualPath.Length)
			{
				// test a special case where virtual path might match the apppath without the trailing slash
				virtualPath = EnsureTrailingForwardSlash(virtualPath);
				if (AppPath.Length > virtualPath.Length)
					throw new Exception("Cannot map virtual path to the current application.");
				else
					return virtualPath.Substring(AppPath.Length);
			}
			else
			{
				return virtualPath.Substring(AppPath.Length);
			}
		}
		public static string PhysicalToVirtual(string physicalPath)
		{

			string pathOfWebRoot = HttpContext.Current.Server.MapPath("/").ToLower();
			physicalPath = physicalPath.ToLower();

			// now look for the web root path in the file path
			int index = physicalPath.IndexOf(pathOfWebRoot);
			if (index == -1)
				throw new Exception("Physical path can't be mapped to the current application.");

			string relUrl = Path.DirectorySeparatorChar.ToString();
			
			index += pathOfWebRoot.Length;;
			relUrl += physicalPath.Substring(index);

			// make slashes consistent
			relUrl = relUrl.Replace("\\", "/");

			return relUrl;

		}

		public static string PhysicalToAbsolute(string physicalPath)
		{
			string virtualPath = PhysicalToVirtual(physicalPath);
			return VirtualToAbsolute(virtualPath);
		}

		public static string PhysicalToApplication(string physicalPath)
		{
			return VirtualToApplication(PhysicalToVirtual(physicalPath));
		}
		public static string AbsoluteToVirtual(string absolutePath)
		{
			string pathOfWebRoot = HttpContext.Current.Server.MapPath("/").ToLower();
			pathOfWebRoot = PhysicalToAbsolute(pathOfWebRoot);
			absolutePath = absolutePath.ToLower();
			int index = absolutePath.IndexOf(pathOfWebRoot);
			if (index < 0)
				throw new Exception("Absolute URL can't be mapped to the current server.");
			string virtualUrl = absolutePath.Substring(index+pathOfWebRoot.Length-1);
			return virtualUrl;
		}
		public static string AbsoluteToPhysical(string absolutePath)
		{
			string virtualUrl = AbsoluteToVirtual(absolutePath);
			string webRoot = VirtualToPhysical("/");
			webRoot = webRoot.Substring(0, webRoot.Length - 1);
			string path = webRoot + virtualUrl.Replace("/", "\\");
			return path;
		}
		public static string AbsoluteToApplication(string absolutePath)
		{
			return VirtualToApplication(AbsoluteToVirtual(absolutePath));
		}
		public static string ApplicationToPhysical(string appRelativePath)
		{
			return VirtualToPhysical(ApplicationToVirtual(appRelativePath));
		}
		public static string ApplicationToVirtual(string appRelativePath)
		{
			return AppPath + appRelativePath;
		}

		public static string ApplicationToAbsolute(string appRelativePath)
		{
			return VirtualToAbsolute(ApplicationToVirtual(appRelativePath));
		}

		#endregion

		#region -- Misc. Methods --

		/// <summary>
		/// Returns the last folder name in a path with a trailing slash
		/// IE. "c:\myfolder\myspace\afile.txt" will return "myspace"
		/// IE. "c:\myfolder\myspace" will return "myfolder"
		/// IE. "myfolder/myspace/" will return "myspace"
		/// IE. "myfolder/myspace" will return "myfolder"
		/// IE. "myspace" will return ""
		/// </summary>
		public static string GetImmediateFolderName(string path)
		{
			//			Supported formats:
			//			c:\myfolder\myspace\
			//			c:\myfolder\myspace\afile.txt
			//			/myfolder/myspace/
			//			/myfolder/myspace/afile.txt
			//			Any text after the last slash is assumed to be a filename

			// ensure all slashes are forward
			path = path.Replace("\\","/");

			string[] fields = path.Split(new char[]{'/'});

			// if we end up with 1 field or less, then there were no slashes in the input path,
			// so we assume the text, if any, was a file name and not a folder
			if (fields.Length < 2)
				return "";

			// if we have 2 or more fields, then the immediate folder is the penultimate (2nd to last)
			// field
			return fields[fields.Length-2];

		}

		/// <summary>
		/// Makes sure the slashes are all going the right direction,.
		/// Back for physical, forward for URL
		/// </summary>
		public static string SyncSlashes(string inputPath)
		{
			// of all the types only Physical gets backward slashes
			if (IsPhysicalPath(inputPath))
				return inputPath.Replace("/", "\\");
			else
			{
				// handle query string
				int qIndex = inputPath.IndexOf("?");
				if (qIndex < 0 || qIndex == inputPath.Length-1)
					return inputPath.Replace("\\", "/");
				else
				{
					string p = inputPath.Substring(0, qIndex);
					string q = inputPath.Substring(qIndex);
					return p.Replace("\\", "/") + q;
				}
			}
		}

		public static string EnsureTrailingForwardSlash(string input)
		{
			if (input == "") 
				return "/";
			if (input[input.Length-1] != '/')
				return input + "/";
			return input;
		}
		public static string EnsureTrailingBackSlash(string input)
		{
			if (input == "") 
				return "\\";
			if (input[input.Length-1] != '\\')
				return input + "\\";
			return input;
		}

		#endregion

		#region -- Parsing --
		/// <summary>
		/// Keys:
		/// s0 = scheme with colon		(http)
		/// s1 = scheme with colon		(http:)
		/// a0 = authority without //	(www.cambiaresearch.com)
		/// a1 = authority with //		(//www.cambiaresearch.com
		/// p0 = path					(/folder1/folder/file.htm)
		/// q0 = query without ?		(id=217&dog=hound)
		/// q1 = query with ?			(?id=217&dog=hound)
		/// f0 = fragment without #		(section17)
		/// f1 = fragment with #		(#section17)
		/// </summary>
		public static Hashtable GetUriSegments(string absoluteInputUrl)
		{
			if (!IsAbsolutePath(absoluteInputUrl))
				throw new Exception("Cannot accurately return URI segments if the input url is not an absolute url containing '://'");

			string regexPattern = @"^(?<s1>(?<s0>[^:/\?#]+):)?(?<a1>" 
				+ @"//(?<a0>[^/\?#]*))?(?<p0>[^\?#]*)" 
				+ @"(?<q1>\?(?<q0>[^#]*))?" 
				+ @"(?<f1>#(?<f0>.*))?";

			Regex re = new Regex(regexPattern, RegexOptions.ExplicitCapture); 
			Match m = re.Match(absoluteInputUrl);

			Hashtable ht = new Hashtable();
			ht["s0"] = m.Groups["s0"].Value; // (Scheme without colon)
			ht["s1"] = m.Groups["s1"].Value; // (Scheme with colon)
			ht["a0"] = m.Groups["a0"].Value; // (Authority without //) 
			ht["a1"] = m.Groups["a1"].Value; // (Authority with //) 
			ht["p0"] = m.Groups["p0"].Value; // (Path)
			ht["q0"] = m.Groups["q0"].Value; // (Query without ?) 
			ht["q1"] = m.Groups["q1"].Value; // (Query with ?) 
			ht["f0"] = m.Groups["f0"].Value; // (Fragment without #) 
			ht["f1"] = m.Groups["f1"].Value; // (Fragment with #) 

			return ht;

		}
		#endregion

	}
	public enum PathType
	{
		None,
		Virtual,
		Absolute,
		Physical,
		AppRelative
	}

}
