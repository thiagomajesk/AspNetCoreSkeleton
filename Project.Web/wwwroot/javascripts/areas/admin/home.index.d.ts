import { ko, ViewModel } from "knockout.bootstrapper";
export declare class AdminHomeIndexViewModel extends ViewModel {
    count: ko.Observable<number>;
    message: ko.Computed<string | null>;
    constructor(params?: any);
    click(): void;
}
