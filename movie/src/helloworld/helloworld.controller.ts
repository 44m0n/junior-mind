import { Controller, Get, Render } from '@nestjs/common';

@Controller('helloworld')
export class HelloworldController {

    @Get()
    @Render('main')
    main() {
        return { text: "This is Hello World!" };
    }

    @Get("welcome")
    @Render('main')
    WelcomeAction() {
        return { text: "This is the Welcomde Action method" };
}
}
