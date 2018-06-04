@echo off

:: Script: GenerateVendor.bat
:: Description: This scripts generates the vendor.js file that contains the angular application.

call npm install
call node node_modules/webpack/bin/webpack.js --config webpack.config.vendor.js --env.prod
call node node_modules/webpack/bin/webpack.js --env.prod