﻿// <copyright file="EdgeDriver.cs" company="Microsoft">
// Licensed to the Software Freedom Conservancy (SFC) under one
// or more contributor license agreements. See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership. The SFC licenses this file
// to you under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;

namespace OpenQA.Selenium.Edge
{
    /// <summary>
    /// Provides a mechanism to write tests against Edge
    /// </summary>
    public class EdgeDriver : RemoteWebDriver
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class.
        /// </summary>
        public EdgeDriver()
            : this(new EdgeOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class using the specified options.
        /// </summary>
        /// <param name="options">The <see cref="EdgeOptions"/> to be used with the Edge driver.</param>
        public EdgeDriver(EdgeOptions options)
            : this(EdgeDriverService.CreateDefaultService(), options, RemoteWebDriver.DefaultCommandTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class using the specified driver service.
        /// </summary>
        /// <param name="service">The <see cref="EdgeDriverService"/> used to initialize the driver.</param>
        public EdgeDriver(EdgeDriverService service)
            : this(service, new EdgeOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class using the specified path 
        /// to the directory containing EdgeDriver.exe.
        /// </summary>
        /// <param name="EdgeDriverDirectory">The full path to the directory containing EdgeDriver.exe.</param>
        public EdgeDriver(string EdgeDriverDirectory)
            : this(EdgeDriverDirectory, new EdgeOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class using the specified path
        /// to the directory containing EdgeDriver.exe and options.
        /// </summary>
        /// <param name="EdgeDriverDirectory">The full path to the directory containing EdgeDriver.exe.</param>
        /// <param name="options">The <see cref="EdgeOptions"/> to be used with the Edge driver.</param>
        public EdgeDriver(string EdgeDriverDirectory, EdgeOptions options)
            : this(EdgeDriverDirectory, options, RemoteWebDriver.DefaultCommandTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class using the specified path
        /// to the directory containing EdgeDriver.exe, options, and command timeout.
        /// </summary>
        /// <param name="EdgeDriverDirectory">The full path to the directory containing EdgeDriver.exe.</param>
        /// <param name="options">The <see cref="EdgeOptions"/> to be used with the Edge driver.</param>
        /// <param name="commandTimeout">The maximum amount of time to wait for each command.</param>
        public EdgeDriver(string EdgeDriverDirectory, EdgeOptions options, TimeSpan commandTimeout)
            : this(EdgeDriverService.CreateDefaultService(EdgeDriverDirectory), options, commandTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class using the specified 
        /// <see cref="EdgeDriverService"/> and options.
        /// </summary>
        /// <param name="service">The <see cref="EdgeDriverService"/> to use.</param>
        /// <param name="options">The <see cref="EdgeOptions"/> used to initialize the driver.</param>
        public EdgeDriver(EdgeDriverService service, EdgeOptions options)
            : this(service, options, RemoteWebDriver.DefaultCommandTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDriver"/> class using the specified <see cref="EdgeDriverService"/>.
        /// </summary>
        /// <param name="service">The <see cref="EdgeDriverService"/> to use.</param>
        /// <param name="options">The <see cref="EdgeOptions"/> to be used with the Edge driver.</param>
        /// <param name="commandTimeout">The maximum amount of time to wait for each command.</param>
        public EdgeDriver(EdgeDriverService service, EdgeOptions options, TimeSpan commandTimeout)
            : base(new DriverServiceCommandExecutor(service, commandTimeout), options.ToCapabilities())
        {
        }
        #endregion
    }
}

