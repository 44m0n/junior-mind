import { Controller, Get, Param, Query, Render, Req } from '@nestjs/common';
import { Request } from 'express';

@Controller('helloworld')
export class HelloworldController {

    @Get()
    @Render('helloworld')
    main() {
        return { text: "This is Hello World!" };
    }

    @Get("Welcome")
    @Render('helloworld')
    WelcomeAction(@Query('name') name, @Query('age') age,) {
            return { text: `Hello ${name}. Your age is ${age}` };
    }
}
