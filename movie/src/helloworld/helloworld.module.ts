import { Module } from '@nestjs/common';
import { HelloworldController } from './helloworld.controller'

@Module({
    imports: [],
    controllers: [HelloworldController],
    providers: []
})
export class HelloworldModule {}
