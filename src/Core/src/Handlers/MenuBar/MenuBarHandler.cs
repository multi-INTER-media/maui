﻿using System;
using System.Collections.Generic;
using System.Text;
#if IOS || MACCATALYST
using PlatformView = UIKit.IUIMenuBuilder;
#elif MONOANDROID
using PlatformView = Android.Views.View;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.MenuBar;
#elif NETSTANDARD || (NET6_0 && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Handlers
{
	public partial class MenuBarHandler : IMenuBarHandler
	{

		public static IPropertyMapper<IMenuBar, IMenuBarHandler> Mapper = new PropertyMapper<IMenuBar, IMenuBarHandler>(ElementMapper)
		{
#if WINDOWS
#endif
		};

		public static CommandMapper<IMenuBar, IMenuBarHandler> CommandMapper = new(ElementCommandMapper)
		{
			[nameof(IMenuBarHandler.Add)] = MapAdd,
			[nameof(IMenuBarHandler.Remove)] = MapRemove,
			[nameof(IMenuBarHandler.Clear)] = MapClear,
			[nameof(IMenuBarHandler.Insert)] = MapInsert,
		};

		public MenuBarHandler() : base(Mapper, CommandMapper)
		{

		}

		public static void MapAdd(IMenuBarHandler handler, IMenuBar layout, object? arg)
		{
			if (arg is MenuBarHandlerUpdate args)
			{
				handler.Add(args.MenuBarItem);
			}
		}

		public static void MapRemove(IMenuBarHandler handler, IMenuBar layout, object? arg)
		{
			if (arg is MenuBarHandlerUpdate args)
			{
				handler.Remove(args.MenuBarItem);
			}
		}

		public static void MapInsert(IMenuBarHandler handler, IMenuBar layout, object? arg)
		{
			if (arg is MenuBarHandlerUpdate args)
			{
				handler.Insert(args.Index, args.MenuBarItem);
			}
		}

		public static void MapClear(IMenuBarHandler handler, IMenuBar layout, object? arg)
		{
			handler.Clear();
		}

		IMenuBar IMenuBarHandler.VirtualView => VirtualView;

		PlatformView IMenuBarHandler.NativeView => NativeView;
	}
}
