import { IError } from "./IError";

export interface Result
{
  isSuccess: boolean;
  isFailure: boolean;
  error?: IError;
}

