<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    if(DB::connection()->getDatabaseName())
    {
        echo "conncted sucessfully to database ".DB::connection()->getDatabaseName();

        $table = DB::table('users')->get();
        dd($table);
    }

});
