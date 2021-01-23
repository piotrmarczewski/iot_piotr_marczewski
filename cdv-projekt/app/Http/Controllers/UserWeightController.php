<?php

namespace App\Http\Controllers;
use Illuminate\Http\Request;

use Illuminate\Support\Facades\Auth;
use App\Models\UserWeight;
use Validator;

class UserWeightController extends Controller
{
    /**
     * Create a new AuthController instance.
     *
     * @return void
     */
    public function __construct() {
        $this->middleware('auth:api');
    }

    public function add(Request $request) {
        
        $validator = Validator::make($request->all(), [
            'weight' => 'required|numeric',
            'date' => 'required|date',
            'description' => 'string|max:150',
            'photo' => 'string',
        ]);

        if($validator->fails()){
            return response()->json($validator->errors()->toJson(), 400);
        }

        $arr = array_merge(
            $validator->validated()
        );
        $arr['user_id'] = auth()->user()->id;

        $weight = UserWeight::create($arr);

        return response()->json([
            'message' => 'Pomyślnie dodano',
            'weight' => $weight
        ], 201);
    }

    public function get()
    {
        return UserWeight::where('user_id', auth()->user()->id)->orderBy('date', 'desc')->get();
    }

    public function getOne(int $id)
    {
        $weights = UserWeight::where('id', $id)->get();
        $weight = $weights[0];
        return $weight;
    }
}
