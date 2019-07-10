import { ko, Component, ViewModelClass, ViewModel } from "knockout.bootstrapper";
import './index.scss';
export declare class HelloWorldComponent extends Component {
    constructor(name?: string, viewModel?: ViewModelClass);
}
export declare class HelloWorldViewModel extends ViewModel {
    isHidden: ko.Observable<boolean>;
    buttonText: ko.Computed<string>;
    constructor(params?: any);
    toggleHello(): void;
}
