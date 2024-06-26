import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { HelloworldModule } from './helloworld/helloworld.module';
import { MovieController } from './movie/movie.controller';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Connection } from 'typeorm';
import { MovieEntity } from './movie/movie.entity';
import { MovieModule } from './movie/movie.module';


@Module({
    imports: [HelloworldModule, TypeOrmModule.forRoot(
        {
            type: "mysql",
            host: "localhost",
            port: 3306,
            username: "root",
            password: "toor",
            database: "Mysql",
            entities: [MovieEntity],
            synchronize: true
        }
            ), MovieModule],
    controllers: [AppController],
    providers: [AppService]
})
export class AppModule {
    constructor(private connection: Connection) { }
}
