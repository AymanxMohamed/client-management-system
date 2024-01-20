import { IError } from "./IError";

export interface Result<TValue>
{
  isSuccess: boolean;
  isFailure: boolean;
  error?: IError;
  value?: TValue;
}
